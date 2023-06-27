using Controllers;
using Profile;
using ScriptableObjects;
using Tool;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MainController : BaseController
    {
        private readonly ResourcePath _resourcePath;
        
        private readonly ProfilePlayers _profilePlayer;
        private readonly SceneTitles _sceneTitles;

        private MainMenuView _mainMenuView;
        private MainMenuController _mainMenuController;

        
        public MainController(ProfilePlayers profilePlayer, Transform placeForUi, SceneTitles sceneTitles, MainMenuAddressPrefabs mainMenuAddressPrefabs)
        {
            _profilePlayer = profilePlayer;
            _sceneTitles = sceneTitles;
            
            _resourcePath = new ResourcePath(mainMenuAddressPrefabs.MainMenu);
            _mainMenuView = LoadView(placeForUi);
            
            profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
            OnChangeGameState(_profilePlayer.CurrentState.Value);
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);
            
            return objectView.GetComponent<MainMenuView>();
        }
        
        private void OnChangeGameState(GameState state)
        {
            DisposeControllers();
            switch (state)
            {
                case GameState.Menu:
                    _mainMenuController = new MainMenuController(_profilePlayer, _mainMenuView);
                    break;
                case GameState.Task_2_1:
                    SceneManager.LoadSceneAsync(_sceneTitles.Scene1);
                    break;
                case GameState.Task_2_2:
                    SceneManager.LoadSceneAsync(_sceneTitles.Scene2);
                    break;
                case GameState.Task_2_3:
                    SceneManager.LoadSceneAsync(_sceneTitles.Scene3);
                    break;
            }
        }
        
        private void DisposeControllers()
        {
            _mainMenuController?.Dispose();
        }
        
        protected override void OnDispose()
        {
            DisposeControllers();
        }
    }
}