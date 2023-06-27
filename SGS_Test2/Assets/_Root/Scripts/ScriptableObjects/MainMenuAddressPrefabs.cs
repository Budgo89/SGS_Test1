using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Main Menu Address Prefabs", menuName = "SGS/MainMenuAddressPrefabs", order = 0)]
    public class MainMenuAddressPrefabs : ScriptableObject
    {
        [SerializeField] private string _mainMenu;

        public string MainMenu => _mainMenu;
    }
}

