using Controllers;
using Profile;
using ScriptableObjects;
using Tool;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Task_2_3
{
    public class Task_2_3MainController : BaseController
    {
        private readonly ResourcePath _resourcePathMenu;
        private readonly ResourcePath _resourcePathPlayerController;
        
        private readonly ProfilePlayers _profilePlayer;
        private readonly SceneTitles _sceneTitles;
        private readonly PlayerConfigController _playerConfigController;
        private readonly GameObject _plaers;
        private readonly Vector3 _cameraPosition;

        private MenuTask_2View _menuTask2View;
        private ControllerView _controllerView;
        private Task_2_3MenuController _task_2_3MenuController;
        private PlayerController _playerController;
        private CameraController _cameraController;
        

        public Task_2_3MainController(ProfilePlayers profilePlayer, Transform placeForUi, SceneTitles sceneTitles,
            Task_2_3AddressPrefabs task23AddressPrefabs, PlayerConfigController playerConfigController,
            GameObject plaers, Vector3 cameraPosition)
        {
            _profilePlayer = profilePlayer;
            _sceneTitles = sceneTitles;
            _playerConfigController = playerConfigController;
            _plaers = plaers;
            _cameraPosition = cameraPosition;

            _resourcePathMenu = new ResourcePath(task23AddressPrefabs.MenuTask_2_3);
            _menuTask2View = LoadMenuView(placeForUi);
            _resourcePathPlayerController = new ResourcePath(task23AddressPrefabs.PlayerController);
            _controllerView = LoadControllerView(placeForUi);
            
            profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
            OnChangeGameState(_profilePlayer.CurrentState.Value);
        }
        
        private void OnChangeGameState(GameState state)
        {
            DisposeControllers();
            switch (state)
            {
                case GameState.Task_2_3:
                    _task_2_3MenuController = new Task_2_3MenuController(_profilePlayer, _menuTask2View);
                    _playerController = new PlayerController(_controllerView, _playerConfigController, _plaers);
                    _cameraController = new CameraController(_plaers, _cameraPosition);
                    break;
                case GameState.Menu:
                    SceneManager.LoadSceneAsync(_sceneTitles.MainMenuScene);
                    break;
            }
        }

        public void UpDate()
        {
            _cameraController.UpDate();
        }

        public void FixedUpdate()
        {
            _playerController.FixedUpdate();
        }
        
        private MenuTask_2View LoadMenuView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePathMenu);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);
            
            return objectView.GetComponent<MenuTask_2View>();
        }
        private ControllerView LoadControllerView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePathPlayerController);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);
            
            return objectView.GetComponent<ControllerView>();
        }
        
        private void DisposeControllers()
        {
            _task_2_3MenuController?.Dispose();
            _playerController?.Dispose();
        }
        
        protected override void OnDispose()
        {
            DisposeControllers();
        }
    }
}
