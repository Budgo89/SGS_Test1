using Controllers;
using Profile;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Task_2_2
{
    public class Task_2_2MainController : BaseController
    {
        private readonly ProfilePlayers _profilePlayer;
        private readonly Transform _placeForUi;
        private readonly SceneTitles _sceneTitles;
        private readonly Task_2_2AddressPrefabs _task_2_2AddressPrefabs;
        private readonly CarConfigController _carConfigController;
        private readonly GameObject _plaers;

        private Task_2_2MenuController _task_2_2MenuController;
        private CarController _carController;
        

        public Task_2_2MainController(ProfilePlayers profilePlayer, Transform placeForUi, SceneTitles sceneTitles,
            Task_2_2AddressPrefabs task_2_2AddressPrefabs, CarConfigController carConfigController, GameObject plaers)
        {
            _profilePlayer = profilePlayer;
            _placeForUi = placeForUi;
            _sceneTitles = sceneTitles;
            _task_2_2AddressPrefabs = task_2_2AddressPrefabs;
            _carConfigController = carConfigController;
            _plaers = plaers;
            profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
            OnChangeGameState(_profilePlayer.CurrentState.Value);
        }

        private void OnChangeGameState(GameState state)
        {
            DisposeControllers();
            switch (state)
            {
                case GameState.Task_2_2:
                    _task_2_2MenuController = new Task_2_2MenuController(_profilePlayer, _placeForUi, _task_2_2AddressPrefabs);
                    _carController = new CarController(_task_2_2MenuController, _carConfigController, _plaers);
                    break;
                case GameState.Menu:
                    SceneManager.LoadSceneAsync(_sceneTitles.MainMenuScene);
                    break;
            }
        }

        private void DisposeControllers()
        {
            _task_2_2MenuController?.Dispose();
            _carController?.Dispose();
        }

        public void UpDate(float deltaTime)
        {
            _carController.UpDate(deltaTime);
        }
        
        protected override void OnDispose()
        {
            DisposeControllers();
        }
    }
}
