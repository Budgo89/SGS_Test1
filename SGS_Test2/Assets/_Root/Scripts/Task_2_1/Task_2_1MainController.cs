using Controllers;
using Profile;
using ScriptableObjects;
using Tool;
using UnityEngine;
using UnityEngine.SceneManagement;
using View;

namespace Task_2_1
{
    public class Task_2_1MainController : BaseController
    {
        private readonly ResourcePath _resourcePath;
        
        private readonly ProfilePlayers _profilePlayer;
        private readonly Transform _placeForUi;
        private readonly SceneTitles _sceneTitles;
        private readonly Task_2_1AddressPrefabs _task21AddressPrefabs;
        
        private Task_2_1MenuController _task_2_1MenuController;
        private Task_2_1RotationalController _rotationalController;
        private IСontrolController _touchController;
        private ColorController _colorController;

        private CubeView _cubeView;

        
        public Task_2_1MainController(ProfilePlayers profilePlayer, Transform placeForUi, SceneTitles sceneTitles, Task_2_1AddressPrefabs task21AddressPrefabs)
        {
            _profilePlayer = profilePlayer;
            _placeForUi = placeForUi;
            _sceneTitles = sceneTitles;
            _task21AddressPrefabs = task21AddressPrefabs;

            _resourcePath = new ResourcePath(task21AddressPrefabs.Cube);
            _cubeView = LoadView();
            
            profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
            OnChangeGameState(_profilePlayer.CurrentState.Value);
        }
        
        private CubeView LoadView()
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObject(objectView);
            
            return objectView.GetComponent<CubeView>();
        }
        
        private void OnChangeGameState(GameState state)
        {
            DisposeControllers();
            switch (state)
            {
                case GameState.Task_2_1:
                    _task_2_1MenuController = new Task_2_1MenuController(_profilePlayer,_placeForUi,_task21AddressPrefabs);
                    _rotationalController = new Task_2_1RotationalController(_cubeView);
#if UNITY_EDITOR
                    _touchController = new MouseController();
#else
                    _touchController = new TouchController();
#endif
                    _colorController = new ColorController(_touchController, _cubeView);
                    break;
                case GameState.Menu:
                    SceneManager.LoadSceneAsync(_sceneTitles.MainMenuScene);
                    break;
            }
        }

        public void UpData()
        {
            _rotationalController.UpData();
            _touchController.UpData();
        }
        private void DisposeControllers()
        {
            _task_2_1MenuController?.Dispose();
            _rotationalController?.Dispose();
            _touchController?.Dispose();
            _colorController?.Dispose();
        }
        
        protected override void OnDispose()
        {
            DisposeControllers();
        }
    }
}