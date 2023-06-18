using Controllers;
using MonoBehaviours;
using Profile;
using UnityEngine.UI;

namespace PictureScene
{
    public class PictureController: BaseController
    {
        private readonly ProfilePlayers _profilePlayer;
        private readonly PictureSceneView _pictureSceneView;
        private readonly SavePictureScene _savePictureScene;
        
        private Button _buttonNext;
        private Image _picture;

        public PictureController(ProfilePlayers profilePlayer, PictureSceneView pictureSceneView, SavePictureScene savePictureScene)
        {
            _profilePlayer = profilePlayer;
            _pictureSceneView = pictureSceneView;
            _savePictureScene = savePictureScene;

            AddElements();
            SubscribeButton();
        }

        private void SubscribeButton()
        {
            _buttonNext.onClick.AddListener(OnButtonNextClick);
        }

        private void OnButtonNextClick()
        {
            _savePictureScene.Destroy();
            _profilePlayer.CurrentState.Value = GameState.Loading;
        }

        private void AddElements()
        {
            _buttonNext = _pictureSceneView.ButtonNext;
            _picture = _pictureSceneView.Picture;
            _picture.sprite = _savePictureScene.Picture;
        }
        
        protected override void OnDispose()
        {
            DisposeControllers();
        }

        private void DisposeControllers()
        {
            _buttonNext.onClick.AddListener(OnButtonNextClick);
        }
    }
}