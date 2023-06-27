using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerView : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Button _jumpButton;
    [SerializeField] private Button _attackButton;

    public FixedJoystick Joystick => _joystick;
    public Button JumpButton => _jumpButton;
    public Button AttackButton => _attackButton;
}
