using MonoBehaviours;
using PictureScene;
using Profile;
using ScriptableObjects;
using UnityEngine;

public class EntryPointPictureScene : MonoBehaviour
{
    [Header("Ориентация экрана")]
    [SerializeField] private ScreenOrientation _orientation = ScreenOrientation.AutoRotation;
    
    [Header("Scene Objects")] 
    [SerializeField] private Transform _placeForUi;
    [Header("Адрес префаба")] 
    [SerializeField] private string _addressPrefabs;
    [Header("Название сцен")] 
    [SerializeField] private SceneTitles _sceneTitles;
    [SerializeField] private CorotinesController _corotinesController;
    
    private ProfilePlayers _profilePlayer;
    private SavePictureScene _savePictureScene;
    private PictureSceneController _pictureSceneController;

    private void Start()
    {
        Screen.orientation = _orientation;
        _profilePlayer = new ProfilePlayers(GameState.Menu);
        _savePictureScene = FindObjectOfType<SavePictureScene>();
        _pictureSceneController = new PictureSceneController(_profilePlayer, _placeForUi, _addressPrefabs, _sceneTitles, _corotinesController, _savePictureScene);
    }
}
