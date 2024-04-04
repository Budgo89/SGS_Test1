using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class VideoRecorder : MonoBehaviour
{
    [Header("RenderTexture")]
    [SerializeField] private RenderTexture _sourceRenderTexture;
    [Header("Video settings")]
    [SerializeField] private int _frameRate = 25;
    [SerializeField] private int _outputWidth = 1280;
    [SerializeField] private int _outputHeight = 720;
    [SerializeField] private int _bitRate = 3000;
    [Header("Broadcast settings")]
    [SerializeField] private string _ffmpegPath = "";
    [SerializeField] private string _host = "127.0.0.1";
    [SerializeField] private string _port = "12345";
    
    private bool isRecording = false;
    private Process ffmpegProcess;

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isRecording)
            {
                Debug.Log("Start Stream...");
                StartRecording();
            }
            else
            {
                Debug.Log("Stop Stream...");
                StopRecording();
            }
        }

        if (isRecording)
        {
            SaveFrame();
        }
    }
    
    private void StartRecording()
    {
        // Параметры командной строки для FFmpeg
        string ffmpegArgs = $"-f rawvideo -pixel_format rgba -s {_sourceRenderTexture.width}x{_sourceRenderTexture.height} -r {_frameRate} -i - " +
                            $"-vf \"scale={_outputWidth}:{_outputHeight},vflip\" -b:v {_bitRate}k -f mpegts tcp://{_host}:{_port}?listen";

        // Настройка и запуск процесса FFmpeg
        ffmpegProcess = new Process
        {
            StartInfo = new ProcessStartInfo(_ffmpegPath, ffmpegArgs)
            {
                UseShellExecute = false,
                RedirectStandardInput = true,
            }
        };

        ffmpegProcess.Start();
        isRecording = true;
    }

    private void SaveFrame()
    {
        // Создание текстуры для хранения текущего кадра из RenderTexture
        Texture2D frame = new Texture2D(_sourceRenderTexture.width, _sourceRenderTexture.height, TextureFormat.RGBA32, false);
        RenderTexture.active = _sourceRenderTexture;
        frame.ReadPixels(new Rect(0, 0, _sourceRenderTexture.width, _sourceRenderTexture.height), 0, 0);
        frame.Apply();

        // Получение сырых данных изображения и их запись в поток ввода FFmpeg
        byte[] rawData = frame.GetRawTextureData();
        ffmpegProcess.StandardInput.BaseStream.Write(rawData, 0, rawData.Length);
        ffmpegProcess.StandardInput.BaseStream.Flush();

        // Уничтожение объекта Texture2D для освобождения памяти
        Destroy(frame);
    }

    private void StopRecording()
    {
        isRecording = false;
        
        // Закрытие потока ввода FFmpeg и ожидание завершения процесса
        ffmpegProcess.StandardInput.Close();
        ffmpegProcess.WaitForExit();
        ffmpegProcess.Close();
    }
}
