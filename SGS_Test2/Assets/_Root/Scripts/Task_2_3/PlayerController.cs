using Controllers;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Task_2_3
{
    public class PlayerController : BaseController
    {
        private readonly ControllerView _controllerView;
        private readonly PlayerConfigController _playerConfigController;
        private readonly GameObject _plaers;
        
        Button _jumpButton;
        Button _attackButton;
        private FixedJoystick _joystick;
        private float _moveSpeed;
        private float _jumpForce;
        private LayerMask _nonGroundMask;
        private Rigidbody _rigidbody;
        private Transform _transform;
        private Animator _animator;

        public PlayerController(ControllerView controllerView, PlayerConfigController playerConfigController, GameObject plaers)
        {
            _controllerView = controllerView;
            _playerConfigController = playerConfigController;
            _plaers = plaers;
            
            _joystick = _controllerView.Joystick;
            _moveSpeed = playerConfigController.MoveSpeed;
            _jumpForce = playerConfigController.JumpForce;
            _nonGroundMask = playerConfigController.NonGroundMask;
            _rigidbody = plaers.GetComponent<Rigidbody>();
            _transform = plaers.GetComponent<Transform>();
            _animator = plaers.GetComponent<Animator>();
            AddButton();
            SubscribeButton();
        }

        private void SubscribeButton()
        {
            _attackButton.onClick.AddListener(OnAttackButtonClick);
            _jumpButton.onClick.AddListener(OnJumpButtonClick);
        }

        private void OnJumpButtonClick()
        {
            if (IsGround())
            {
                _animator.SetBool("jump", true);
                _rigidbody.AddForce(Vector3.up *_jumpForce, ForceMode.Impulse);
            }
        }

        private bool IsGround()
        {
            return Physics.CheckSphere(_transform.position, 0.2f, _nonGroundMask);
        }

        private void OnAttackButtonClick()
        {
            _animator.SetBool("attack", true);
        }

        private void AddButton()
        {
            _jumpButton = _controllerView.JumpButton;
            _attackButton = _controllerView.AttackButton;
        }

        public void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            Vector3 moveVector = new Vector3(_joystick.Horizontal, 0.0f, _joystick.Vertical);
            _rigidbody.velocity = new Vector3(moveVector.x * _moveSpeed,_rigidbody.velocity.y,moveVector.z * _moveSpeed);
            var vertical = _joystick.Vertical;
            _animator.SetFloat("run", vertical);
            var horizontal = _joystick.Horizontal;
            _animator.SetFloat("RunSide",horizontal);
            
            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                _transform.rotation = Quaternion.LookRotation(moveVector);
            }

            if (!IsGround())
            {
                _animator.SetBool("jump", false);
            }

            if (IsAnimationAttack("Draw Arrow"))
            {
                _animator.SetBool("attack", false);
            }
        }

        private bool IsAnimationAttack(string drawArrow)
        {
            var animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            if (animatorStateInfo.IsName(drawArrow))             
                return true;
            return false;
        }


        protected override void OnDispose()
        {
            DisposeControllers();
        }

        private void DisposeControllers()
        {
            _attackButton.onClick.RemoveAllListeners();
            _jumpButton.onClick.RemoveAllListeners();
        }
    }
}