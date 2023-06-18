using UnityEngine;
using UnityEngine.UI;

public class GalleryView : MonoBehaviour
{
    [SerializeField] private Slider _progressBar;
    [SerializeField] private Transform _content;
    [SerializeField] private GameObject _scrollView;

    public Slider ProgressBar => _progressBar;
    public Transform Content => _content;
    public GameObject ScrollView => _scrollView;
}
