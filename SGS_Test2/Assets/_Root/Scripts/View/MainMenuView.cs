using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _task_2_1;
    [SerializeField] private Button _task_2_2;
    [SerializeField] private Button _task_2_3;

    public Button Task_2_1 => _task_2_1;
    public Button Task_2_2 => _task_2_2;
    public Button Task_2_3 => _task_2_3;
}
