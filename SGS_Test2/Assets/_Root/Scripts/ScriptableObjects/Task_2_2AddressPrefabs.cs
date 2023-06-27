using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Task_2_2AddressPrefabs", menuName = "SGS/Task_2_2AddressPrefabs", order = 0)]
    public class Task_2_2AddressPrefabs : ScriptableObject
    {
        [SerializeField] private string _menuTask_2;
        [SerializeField] private string _controllerCar;

        public string MenuTask_2 => _menuTask_2;
        public string CarController => _controllerCar;
    }
}