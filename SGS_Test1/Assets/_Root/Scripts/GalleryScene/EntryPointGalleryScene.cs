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
        [SerializeField] private string _addressPrefabs;
        [SerializeField] private string _addressContentImage;
        [SerializeField] private string _addressSavePicture;
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
            _resourcePathSavePicture = new ResourcePath(_addressSavePicture);
            var savePicture = LoadViewSavePictureScene();
            savePicture.SavePicture();
            _gallerySceneController = new GallerySceneController(_profilePlayer, _addressPrefabs, _addressContentImage, _placeForUi,
                _sceneTitles, _corotinesController, _url, _mainCamera, savePicture);
        }
        
        private void Update()
        {
            _gallerySceneController.Update();
        }

        private void OnDestroy()
        {
            _gallerySceneController.Dispose();
        }
        
        private SavePictureScene LoadViewSavePictureScene()
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePathSavePicture);
            GameObject objectView = Object.Instantiate(prefab);
            
            return objectView.GetComponent<SavePictureScene>();
        }
    }
}

