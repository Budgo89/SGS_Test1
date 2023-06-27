using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Task_2_1_AddressPrefabs", menuName = "SGS/Task_2_1AddressPrefabs", order = 0)]
    public class Task_2_1AddressPrefabs : ScriptableObject
    {
        [SerializeField] private string _menuTask_2_1;
        [SerializeField] private string _cube;

        public string MenuTask_2_1 => _menuTask_2_1;
        public string Cube => _cube;
    }
}