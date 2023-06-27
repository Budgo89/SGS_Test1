using System;
using Profile;
using ScriptableObjects;
using UnityEngine;

namespace Task_2_3
{
    public class EntryPointTask_2_3 : MonoBehaviour
    {
        [Header("Ориентация экрана")]
        [SerializeField] private ScreenOrientation _orientation = ScreenOrientation.Portrait;
        [Header("ScriptableObjects")] 
        [SerializeField] private SceneTitles _sceneTitles;
        [SerializeField] private Task_2_3AddressPrefabs _task_2_3AddressPrefabs;
        [SerializeField] private PlayerConfigController _playerConfigController;
        [Header("Игрок")] 
        [SerializeField] private GameObject _plaers;
        [Header("Scene Objects")] 
        [SerializeField] private Transform _placeForUi;
        [Header("Растояние от игрока до камеры")]
        [SerializeField] private Vector3 _cameraPosition;
    
        private ProfilePlayers _profilePlayer;
        private Task_2_3MainController _task_2_3MainController;
        
        
        void Start()
        {
            Screen.orientation = _orientation;
            _profilePlayer = new ProfilePlayers(GameState.Task_2_3);
            _task_2_3MainController = new Task_2_3MainController(_profilePlayer, _placeForUi, _sceneTitles, _task_2_3AddressPrefabs, _playerConfigController, _plaers, _cameraPosition);
        }

        private void FixedUpdate()
        {
            _task_2_3MainController?.FixedUpdate();
        }

        private void Update()
        {
            _task_2_3MainController?.UpDate();
        }
        
        private void OnDestroy()
        {
            _task_2_3MainController?.Dispose();
        }
    }
}

