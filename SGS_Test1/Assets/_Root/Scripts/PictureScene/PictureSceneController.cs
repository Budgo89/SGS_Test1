using Controllers;
using MonoBehaviours;
using Profile;
using ScriptableObjects;
using Tool;
using UnityEngine;

namespace PictureScene
{
    public class PictureSceneController: BaseController
    {
        private readonly ResourcePath _resourcePath;
        
        private readonly ProfilePlayers _profilePlayer;
        private readonly SceneTitles _sceneTitles;
        private readonly CorotinesController _corotinesController;
        private readonly SavePictureScene _savePictureScene;
        private PictureSceneView _pictureSceneView;

        private PictureController _pictureController;
        private LoadingPictureController _loadingPictureController;

        public PictureSceneController(ProfilePlayers profilePlayer, Transform placeForUi, string addressPrefabs, SceneTitles sceneTitles, 
            CorotinesController corotinesController, SavePictureScene savePictureScene)
        {
            _profilePlayer = profilePlayer;
            _sceneTitles = sceneTitles;
            _corotinesController = corotinesController;
            _savePictureScene = savePictureScene;

            _resourcePath = new ResourcePath(addressPrefabs);
            _pictureSceneView = LoadView(placeForUi);
            
            profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
            OnChangeGameState(_profilePlayer.CurrentState.Value);
        }

        private void OnChangeGameState(GameState state)
        {
            DisposeControllers();
            switch (state)
            {
                case GameState.Menu:
                    _pictureController = new PictureController(_profilePlayer, _pictureSceneView, _savePictureScene );
                    break;
                case GameState.Loading:
                    _loadingPictureController = new LoadingPictureController(_pictureSceneView, _corotinesController, _sceneTitles.GalleryScene);
                    break;
            }
        }

        private void DisposeControllers()
        {
            _loadingPictureController?.Dispose();
            _pictureController?.Dispose();
        
        }

        private PictureSceneView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);
            
            return objectView.GetComponent<PictureSceneView>();
        }
    }
}