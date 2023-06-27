using UnityEngine;
using UnityEngine.UI;

public class ControllerCarView : MonoBehaviour
{
    [SerializeField] private Button _forwardButton;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _rightButton;
    [SerializeField] private Button _leftButton;

    public Button ForwardButton => _forwardButton;
    public Button BackButton => _backButton;
    public Button RightButton => _rightButton;
    public Button LeftButton => _leftButton;
}
