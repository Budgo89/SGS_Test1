using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Scene Titles", menuName = "SGS/SceneManager", order = 51)]
    public class SceneTitles : ScriptableObject
    {
        [SerializeField] private string _mainMenuScene = "MainMenu";
        [SerializeField] private string _galleryScene = "GalleryScene";
        [SerializeField] private string _pictureScene = "PictureScene";

        public string MainMenuScene => _mainMenuScene;
        public string GalleryScene => _galleryScene;
        public string PictureScene => _pictureScene;
    }
}