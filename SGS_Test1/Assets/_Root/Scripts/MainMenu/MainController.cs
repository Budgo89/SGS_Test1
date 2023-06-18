using Controllers;
using Profile;
using ScriptableObjects;
using Tool;
using UnityEngine;

namespace MainMenu
{
    public class MainController : BaseController
    {
        private readonly ProfilePlayers _profilePlayer;
        private readonly SceneTitles _sceneTitles;
        private readonly CorotinesController _corotinesController;
        private readonly ResourcePath _resourcePath;
        
        private MainMenuView _mainMenuView;

        private MainMenuController _mainMenuController;
        private LoadingController _loadingController;

        public MainController(ProfilePlayers profilePlayer, string addressPrefabs, Transform placeForUi, SceneTitles sceneTitles, CorotinesController corotinesController)
        {
            _profilePlayer = profilePlayer;
            _sceneTitles = sceneTitles;
            _corotinesController = corotinesController;
            
            _resourcePath = new ResourcePath(addressPrefabs);
            _mainMenuView = LoadView(placeForUi);
            
            profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
            OnChangeGameState(_profilePlayer.CurrentState.Value);
        }

        private void OnChangeGameState(GameState state)
        {
            DisposeControllers();
            switch (state)
            {
                case GameState.Menu:
                    _mainMenuController = new MainMenuController(_profilePlayer, _mainMenuView);
                    break;
                case GameState.Loading:
                    _loadingController = new LoadingController(_profilePlayer,_mainMenuView, _corotinesController, _sceneTitles.GalleryScene);
                    break;

            }
        }

        private void DisposeControllers()
        {
            _mainMenuController?.Dispose();
            _loadingController?.Dispose();
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);
            
            return objectView.GetComponent<MainMenuView>();
        }
        
        protected override void OnDispose()
        {
            DisposeControllers();
        }
    }
}