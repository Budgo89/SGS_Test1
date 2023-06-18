using UnityEngine;
using UnityEngine.UI;

public class PictureSceneView : MonoBehaviour
{
    [SerializeField] private Button _buttonNext;
    [SerializeField] private Image _picture;
    [SerializeField] private Slider _progressBar;
    [SerializeField] private GameObject _pictureGameObject;

    public Button ButtonNext => _buttonNext;
    public Image Picture => _picture;
    public Slider ProgressBar => _progressBar;
    public GameObject PictureGameObject => _pictureGameObject;
    
}
