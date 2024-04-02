using System.Collections;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;
using Debug = UnityEngine.Debug;

public class StreamToFFplay : MonoBehaviour
{
    [SerializeField] private RenderTexture _renderTexture;
    [SerializeField] private int _fps = 30; 
    [SerializeField] private int _width = 1920;
    [SerializeField] private int _height = 1080;
    [SerializeField] private int _bitrate = 2500;
    [SerializeField] private string _streamAddress = "tcp://127.0.0.1:12345";

    private const string FileName = "temp_frame.png";

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(CaptureFramesCoroutine());
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(CaptureFramesCoroutine());
        }
    }

    private IEnumerator CaptureFramesCoroutine()
    {
        var waitTime = new WaitForSeconds(1f / _fps);
        while (true)
        {
            yield return waitTime;
            AsyncGPUReadback.Request(_renderTexture, 0, TextureFormat.RGBA32, OnCompleteReadBack);
        }
    }

    private void OnCompleteReadBack(AsyncGPUReadbackRequest request)
    {
        if (request.hasError)
        {
            Debug.LogError("GPU readback error.");
            return;
        }

        Texture2D texture = new Texture2D(_renderTexture.width, _renderTexture.height, TextureFormat.RGBA32, false);
        texture.LoadRawTextureData(request.GetData<uint>());
        texture.Apply();
        string path = SaveTextureAsPNG(texture);
        SendFrameThroughFFmpeg(path);
    }

    private string SaveTextureAsPNG(Texture2D texture)
    {
        byte[] imageBytes = texture.EncodeToPNG();
        string filePath = Path.Combine(Application.temporaryCachePath, FileName);
        File.WriteAllBytes(filePath, imageBytes);
        return filePath;
    }

    private void SendFrameThroughFFmpeg(string imagePath)
    {
        string ffmpegArgs = $"-re -loop 1 -framerate {_fps} -i {imagePath} -s {_width}x{_height} -b:v {_bitrate}k -f mpegts {_streamAddress}";

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "ffmpeg",
            Arguments = ffmpegArgs,
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };
        
        using (var ffmpegProcess = Process.Start(startInfo))
        {
            ffmpegProcess.EnableRaisingEvents = true;
            ffmpegProcess.Exited += (sender, args) =>
            {
                ffmpegProcess.WaitForExit();
                ffmpegProcess.Dispose();
                File.Delete(imagePath);
            };
        }
    }
}
