using Profile;
using ScriptableObjects;
using UnityEngine;

namespace Task_2_2
{
    public class EntryPointTask_2_2 : MonoBehaviour
    {
        [Header("Ориентация экрана")]
        [SerializeField] private ScreenOrientation _orientation = ScreenOrientation.Portrait;
        [Header("ScriptableObjects")] 
        [SerializeField] private SceneTitles _sceneTitles;
        [SerializeField] private Task_2_2AddressPrefabs _task_2_2AddressPrefabs;
        [SerializeField] private CarConfigController _carConfigController;
        [Header("Scene Objects")] 
        [SerializeField] private Transform _placeForUi;
        [Header("Игрок")] 
        [SerializeField] private GameObject _plaers;
        
        private ProfilePlayers _profilePlayer;
        private Task_2_2MainController _task_2_2MainController;
        
        void Start()
        {
            Screen.orientation = _orientation;
            _profilePlayer = new ProfilePlayers(GameState.Task_2_2);
            _task_2_2MainController = new Task_2_2MainController(_profilePlayer, _placeForUi, _sceneTitles, _task_2_2AddressPrefabs, _carConfigController, _plaers);
        }

        private void Update()
        {
            _task_2_2MainController?.UpDate(Time.deltaTime);
        }
        private void OnDestroy()
        {
            _task_2_2MainController?.Dispose();
        }
    }
}