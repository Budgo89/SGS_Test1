using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _galleryButton;
    [SerializeField] private Slider _progressBar;

    public Button GalleryButton => _galleryButton;
    public Slider ProgressBar => _progressBar;
}
