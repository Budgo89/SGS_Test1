using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Task_2_3_AddressPrefabs", menuName = "SGS/Task_2_3AddressPrefabs", order = 0)]
    public class Task_2_3AddressPrefabs : ScriptableObject
    {
        [SerializeField] private string _menuTask_2_3;
        [SerializeField] private string _playerController;
        
        
        public string MenuTask_2_3 => _menuTask_2_3;
        public string PlayerController => _playerController;
    }
}