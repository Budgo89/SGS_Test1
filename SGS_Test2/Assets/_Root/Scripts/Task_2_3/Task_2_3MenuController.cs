using Controllers;
using Profile;
using UnityEngine.UI;

namespace Task_2_3
{
    public class Task_2_3MenuController : BaseController
    {
        private readonly ProfilePlayers _profilePlayer;
        private readonly MenuTask_2View _menuTask2View;

        private Button _menuTask_2Button;
        

        public Task_2_3MenuController(ProfilePlayers profilePlayer, MenuTask_2View menuTask2View)
        {
            _profilePlayer = profilePlayer;
            _menuTask2View = menuTask2View;
            
            AddButton();
            SubscribeButton();
        }

        private void SubscribeButton()
        {
            _menuTask_2Button.onClick.AddListener(OnMenuTask_2_1ButtonClick);
        }
        
        private void OnMenuTask_2_1ButtonClick() => _profilePlayer.CurrentState.Value = GameState.Menu;

        private void AddButton()
        {
            _menuTask_2Button = _menuTask2View.MenuTask_2_1Button;
        }
        
        protected override void OnDispose()
        {
            DisposeControllers();
        }

        private void DisposeControllers()
        {
            _menuTask_2Button.onClick.RemoveAllListeners();
        }
    }
}