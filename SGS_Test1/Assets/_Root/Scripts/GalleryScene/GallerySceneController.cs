using Controllers;
using MonoBehaviours;
using Profile;
using ScriptableObjects;
using Tool;
using UnityEngine;

namespace GalleryScene
{
    public class GallerySceneController : BaseController
    {
        private readonly ResourcePath _resourcePath;

        private readonly ProfilePlayers _profilePlayer;
        private readonly string _addressContentImage;
        private readonly SceneTitles _sceneTitles;
        private readonly CorotinesController _corotinesController;
        private readonly string _url;
        private readonly SavePictureScene _savePictureScene;
        private readonly string _addressSavePicture;
        private readonly Camera _mainCamera;

        private GalleryView _galleryView;
        
        private GalleryController _galleryController;
        private LoadingGalleryController _loadingGalleryController;
        

        public GallerySceneController(ProfilePlayers profilePlayer, string addressPrefabs, string addressContentImage,
            Transform placeForUi, SceneTitles sceneTitles, CorotinesController corotinesController, string url, Camera _mainCamera,
            SavePictureScene savePictureScene)
        {
            _profilePlayer = profilePlayer;
            _addressContentImage = addressContentImage;
            _sceneTitles = sceneTitles;
            _corotinesController = corotinesController;
            _url = url;
            _savePictureScene = savePictureScene;

            _resourcePath = new ResourcePath(addressPrefabs);
            _galleryView = LoadView(placeForUi);
            
            profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
            OnChangeGameState(_profilePlayer.CurrentState.Value);
        }

        private void OnChangeGameState(GameState state)
        {
            DisposeControllers();
            switch (state)
            {
                case GameState.Menu:
                    _galleryController = new GalleryController(_profilePlayer, _galleryView, _addressContentImage, _url, _mainCamera, _savePictureScene );
                    break;
                case GameState.Loading:
                    _loadingGalleryController = new LoadingGalleryController(_galleryView, _corotinesController, _sceneTitles.PictureScene);
                    break;
            }
        }

        private void DisposeControllers()
        {
            _loadingGalleryController?.Dispose();
            _galleryController?.Dispose();
        }

        private GalleryView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);
            
            return objectView.GetComponent<GalleryView>();
        }

        public void Update()
        {
            _galleryController.Update();
        }
    }
}