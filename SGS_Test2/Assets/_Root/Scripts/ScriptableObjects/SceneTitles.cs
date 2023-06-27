using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Scene Titles", menuName = "SGS/SceneManager", order = 51)]
    public class SceneTitles : ScriptableObject
    {
        [SerializeField] private string _mainMenuScene = "MainMenu";
        [SerializeField] private string _scene1;
        [SerializeField] private string _scene2;
        [SerializeField] private string _scene3;

        public string MainMenuScene => _mainMenuScene;
        public string Scene1 => _scene1;
        public string Scene2 => _scene2;
        public string Scene3 => _scene3;
    }
}