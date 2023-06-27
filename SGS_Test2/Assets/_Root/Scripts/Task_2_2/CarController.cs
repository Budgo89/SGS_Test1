using System;
using Controllers;
using ScriptableObjects;
using UnityEngine;

namespace Task_2_2
{
    public class CarController : BaseController
    {
        private readonly Task_2_2MenuController _task_2_2MenuController;
        private readonly CarConfigController _carConfigController;
        private readonly GameObject _plaers;
        private float _speed;
        private float _rotation;
        private float _moveSpeedMax;
        private float _moveSpeedMin;
        private float _rotationMax;
        
        private Action _forwardAction;
        private Action _backAction;
        private Action _rightAction;
        private Action _leftAction;

        private float _currentSpeed;
        private float _currentRotation;
        
        private bool _isSpeed = false;
        private bool _isRotation = false;

        public CarController(Task_2_2MenuController task_2_2MenuController, CarConfigController carConfigController, GameObject plaers)
        {
            _task_2_2MenuController = task_2_2MenuController;
            _carConfigController = carConfigController;
            _speed = _carConfigController.MoveSpeed;
            _rotation = _carConfigController.Rotation;
            _moveSpeedMax = _carConfigController.MoveSpeedMax;
            _moveSpeedMin = _carConfigController.MoveSpeedMin;
            _rotationMax = _carConfigController.RotationMax;
            _plaers = plaers;
            SubscribeButton();
        }

        private void SubscribeButton()
        {
            _forwardAction = _task_2_2MenuController.ForwardAction += ForwardAction;
            _backAction = _task_2_2MenuController.BackAction += BackAction;
            _rightAction = _task_2_2MenuController.RightAction += RightAction;
            _leftAction = _task_2_2MenuController.LeftAction += LeftAction;
        }

        public void UpDate(float deltaTime)
        {
            _plaers.transform.Translate(0,0, _currentSpeed * deltaTime);
            _plaers.transform.Rotate(0,_currentRotation,0);
        }
        
        private void LeftAction()
        {
            if (_rotation > 0)
            {
                _rotation *= -1;
            }
            _currentRotation = _currentRotation + _rotation < -_rotationMax
                ? _currentRotation
                :_currentRotation += _rotation;
        }

        private void RightAction()
        {
            if (_rotation < 0)
            {
                _rotation *= -1;
            }
            _currentRotation = _currentRotation + _rotation > _rotationMax
                ? _currentRotation
                :_currentRotation += _rotation;
        }

        private void BackAction()
        {
            if (_speed > 0)
            {
                _speed *= -1;
            }
            _currentSpeed = _currentSpeed + _speed < _moveSpeedMin
                ? _currentSpeed
                :_currentSpeed += _speed;
        }

        private void ForwardAction()
        {
            if (_speed < 0)
            {
                _speed *= -1;
            }
            _currentSpeed = _currentSpeed + _speed > _moveSpeedMax
                ? _currentSpeed
                :_currentSpeed += _speed;
        }
        
        private void DisposeControllers()
        {
            _forwardAction -= ForwardAction;
            _backAction -= BackAction;
            _rightAction -= RightAction;
            _leftAction -= LeftAction;
        }
        
        protected override void OnDispose()
        {
            DisposeControllers();
        }
    }
}