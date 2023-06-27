using Profile;
using ScriptableObjects;
using UnityEngine;

namespace Task_2_1
{
    public class EntryPointTask_2_1 : MonoBehaviour
    {
        [Header("Ориентация экрана")]
        [SerializeField] private ScreenOrientation _orientation = ScreenOrientation.Portrait;
        [Header("ScriptableObjects")] 
        [SerializeField] private SceneTitles _sceneTitles;
        [SerializeField] private Task_2_1AddressPrefabs _task_2_1AddressPrefabs;
        [Header("Scene Objects")] 
        [SerializeField] private Transform _placeForUi;
    
        private ProfilePlayers _profilePlayer;
        private Task_2_1MainController _task_2_1MainController;

        void Start()
        {
            Screen.orientation = _orientation;
            _profilePlayer = new ProfilePlayers(GameState.Task_2_1);
            _task_2_1MainController = new Task_2_1MainController(_profilePlayer, _placeForUi, _sceneTitles, _task_2_1AddressPrefabs);
        }

        private void Update()
        {
            _task_2_1MainController.UpData();
        }

        private void OnDestroy()
        {
            _task_2_1MainController?.Dispose();
        }
    }
}