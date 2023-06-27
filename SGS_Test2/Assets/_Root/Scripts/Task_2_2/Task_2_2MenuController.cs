using System;
using Controllers;
using Profile;
using ScriptableObjects;
using Tool;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Task_2_2
{
    public class Task_2_2MenuController : BaseController
    {
        private readonly ResourcePath _resourcePathMenu;
        private readonly ResourcePath _resourcePathCarController;
        
        private readonly ProfilePlayers _profilePlayer;
        
        private MenuTask_2View _menuTask2View;
        private ControllerCarView _controllerCarView;
        private Button _menuTask_2Button;
        private Button _forwardButton;
        private Button _backButton;
        private Button _rightButton;
        private Button _leftButton;

        public Action ForwardAction;
        public Action BackAction;
        public Action RightAction;
        public Action LeftAction;
        
        
        public Task_2_2MenuController(ProfilePlayers profilePlayer, Transform placeForUi, Task_2_2AddressPrefabs task_2_2AddressPrefabs)
        {
            _profilePlayer = profilePlayer;

            _resourcePathMenu = new ResourcePath(task_2_2AddressPrefabs.MenuTask_2);
            _menuTask2View = LoadViewMenu(placeForUi);
            _resourcePathCarController = new ResourcePath(task_2_2AddressPrefabs.CarController);
            _controllerCarView = LoadViewCarController(placeForUi);
            
            AddButton();
            SubscribeButton();
        }

        private void SubscribeButton()
        {
            _menuTask_2Button.onClick.AddListener(OnMenuTask_2ButtonClick);
            _forwardButton.onClick.AddListener(OnForwardButtonClick);
            _backButton.onClick.AddListener(OnBackButtonClick);
            _rightButton.onClick.AddListener(OnRightButtonClick);
            _leftButton.onClick.AddListener(OnLeftButtonClick);
        }

        private void OnForwardButtonClick() => ForwardAction?.Invoke();

        private void OnBackButtonClick() => BackAction?.Invoke();

        private void OnRightButtonClick() => RightAction?.Invoke();

        private void OnLeftButtonClick() => LeftAction?.Invoke();
        
        private void OnMenuTask_2ButtonClick() => _profilePlayer.CurrentState.Value = GameState.Menu;

        private void AddButton()
        {
            _menuTask_2Button = _menuTask2View.MenuTask_2_1Button;
            _forwardButton = _controllerCarView.ForwardButton;
            _backButton = _controllerCarView.BackButton;
            _rightButton = _controllerCarView.RightButton;
            _leftButton = _controllerCarView.LeftButton;
        }

        private MenuTask_2View LoadViewMenu(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePathMenu);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);
            
            return objectView.GetComponent<MenuTask_2View>();
        }
        
        private ControllerCarView LoadViewCarController(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePathCarController);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);
            
            return objectView.GetComponent<ControllerCarView>();
        }
        
        protected override void OnDispose()
        {
            DisposeControllers();
        }

        private void DisposeControllers()
        {
            _menuTask_2Button.onClick.RemoveAllListeners();
            _forwardButton.onClick.RemoveAllListeners();
            _backButton.onClick.RemoveAllListeners();
            _rightButton.onClick.RemoveAllListeners();
            _leftButton.onClick.RemoveAllListeners();
        }
    }
}