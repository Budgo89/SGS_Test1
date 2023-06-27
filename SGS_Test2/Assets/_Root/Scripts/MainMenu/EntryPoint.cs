using Profile;
using ScriptableObjects;
using UnityEngine;

namespace MainMenu
{
    public class EntryPoint : MonoBehaviour
    {
        [Header("Ориентация экрана")]
        [SerializeField] private ScreenOrientation _orientation = ScreenOrientation.Portrait;
        [Header("ScriptableObjects")] 
        [SerializeField] private SceneTitles _sceneTitles;
        [SerializeField] private MainMenuAddressPrefabs _mainMenuAddressPrefabs;
        [Header("Scene Objects")] 
        [SerializeField] private Transform _placeForUi;
    
        private ProfilePlayers _profilePlayer;
        private MainController _mainController;
        
        void Start()
        {
            Screen.orientation = _orientation;
            _profilePlayer = new ProfilePlayers(GameState.Menu);
            _mainController = new MainController(_profilePlayer, _placeForUi, _sceneTitles, _mainMenuAddressPrefabs);
        }
        
        private void OnDestroy()
        {
            _mainController?.Dispose();
        }
    }
}


