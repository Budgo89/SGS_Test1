using MonoBehaviours;
using Profile;
using ScriptableObjects;
using Tool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GalleryScene
{
    public class EntryPointGalleryScene : MonoBehaviour
    {
        private ResourcePath _resourcePathSavePicture;
        
        [Header("Ориентация экрана")]
        [SerializeField] private ScreenOrientation _orientation = ScreenOrientation.Portrait;
        [Header("Scene Objects")] 
        [SerializeField] private Transform _placeForUi;
        [Header("Адрес префабов")] 
        [SerializeField] private AddressPrefabsGallery _addressPrefabsGallery;
        [Header("Название сцен")] 
        [SerializeField] private SceneTitles _sceneTitles;

        [SerializeField] private CorotinesController _corotinesController;
        
        [Header("URL для загрузки картинок")]
        [SerializeField] private string _url;
        
        [SerializeField] private Camera _mainCamera;

        private ProfilePlayers _profilePlayer;
        private GallerySceneController _gallerySceneController;
    
    
        void Start()
        {
            Screen.orientation = _orientation;
            _profilePlayer = new ProfilePlayers(GameState.Menu);
            _resourcePathSavePicture = new ResourcePath(_addressPrefabsGallery.AddressSavePicture);
            var savePicture = LoadViewSavePictureScene();
            savePicture.SavePicture();
            _gallerySceneController = new GallerySceneController(_profilePlayer, _addressPrefabsGallery, _placeForUi,
                _sceneTitles, _corotinesController, _url, _mainCamera, savePicture);
        }
        
        private void Update()
        {
            _gallerySceneController.Update();
        }
        
        private SavePictureScene LoadViewSavePictureScene()
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePathSavePicture);
            GameObject objectView = Object.Instantiate(prefab);
            
            return objectView.GetComponent<SavePictureScene>();
        }

        private void OnDestroy()
        {
            _gallerySceneController.Dispose();
        }
    }
}

