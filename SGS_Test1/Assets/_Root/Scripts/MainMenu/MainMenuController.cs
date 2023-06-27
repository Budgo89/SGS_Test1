using Controllers;
using Profile;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuController : BaseController
    {
        private readonly ProfilePlayers _profilePlayer;
        private readonly MainMenuView _mainMenuView;
        
        private Button _galleryButton;

        
        public MainMenuController(ProfilePlayers profilePlayer, MainMenuView mainMenuView)
        {
            _profilePlayer = profilePlayer;
            _mainMenuView = mainMenuView;
            
            AddButton();
            SubscribeButton();
        }

        private void SubscribeButton()
        {
            _galleryButton.onClick.AddListener(OnGalleryButtonClick);
        }

        private void OnGalleryButtonClick() => _profilePlayer.CurrentState.Value = GameState.Loading;

        private void AddButton()
        {
            _galleryButton = _mainMenuView.GalleryButton;
        }
        
        protected override void OnDispose()
        {
            DisposeControllers();
        }

        private void DisposeControllers()
        {
            _galleryButton.onClick.RemoveAllListeners();
        }
    }
}