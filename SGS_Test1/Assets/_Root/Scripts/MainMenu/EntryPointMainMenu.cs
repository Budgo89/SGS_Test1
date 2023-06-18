using Profile;
using ScriptableObjects;
using UnityEngine;

namespace MainMenu
{
    public class EntryPointMainMenu : MonoBehaviour
    {   
        [Header("Ориентация экрана")]
        [SerializeField] private ScreenOrientation _orientation = ScreenOrientation.Portrait;
        [Header("Scene Objects")] 
        [SerializeField] private Transform _placeForUi;
        [Header("Адрес префаба")] 
        [SerializeField] private string _addressPrefabs;
        [Header("Название сцен")] 
        [SerializeField] private SceneTitles _sceneTitles;

        [SerializeField] private CorotinesController _corotinesController;

        private ProfilePlayers _profilePlayer;
        private MainController _mainController;
    
        void Start()
        {
            Screen.orientation = _orientation;
            _profilePlayer = new ProfilePlayers(GameState.Menu);
            _mainController = new MainController(_profilePlayer, _addressPrefabs, _placeForUi, _sceneTitles, _corotinesController);
        }
        
        private void OnDestroy()
        {
            _mainController.Dispose();
        }
    }
}

