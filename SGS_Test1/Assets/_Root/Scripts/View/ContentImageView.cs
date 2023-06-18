using UnityEngine;
using UnityEngine.UI;

public class ContentImageView : MonoBehaviour
{
    [SerializeField] private Image _images;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Button _imageButton;

    public Image Images => _images;
    public RectTransform RectTransforms => _rectTransform;
    public Button ImageButton => _imageButton;
}
