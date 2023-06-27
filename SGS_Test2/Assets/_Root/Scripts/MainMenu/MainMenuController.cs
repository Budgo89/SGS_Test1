using Controllers;
using Profile;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuController : BaseController
    {
        private readonly ProfilePlayers _profilePlayer;
        private readonly MainMenuView _mainMenuView;

        private Button _task_2_1;
        private Button _task_2_2;
        private Button _task_2_3;

        
        public MainMenuController(ProfilePlayers profilePlayer, MainMenuView mainMenuView)
        {
            _profilePlayer = profilePlayer;
            _mainMenuView = mainMenuView;

            AddButton();
            SubscribeButton();
        }

        private void SubscribeButton()
        {
            _task_2_1.onClick.AddListener(OnTask_2_1Click);
            _task_2_2.onClick.AddListener(OnTask_2_2Click);
            _task_2_3.onClick.AddListener(OnTask_2_3Click);
        }

        private void OnTask_2_1Click() => _profilePlayer.CurrentState.Value = GameState.Task_2_1;
        
        private void OnTask_2_2Click() => _profilePlayer.CurrentState.Value = GameState.Task_2_2;
        
        private void OnTask_2_3Click() => _profilePlayer.CurrentState.Value = GameState.Task_2_3;

        private void AddButton()
        {
            _task_2_1 = _mainMenuView.Task_2_1;
            _task_2_2 = _mainMenuView.Task_2_2;
            _task_2_3 = _mainMenuView.Task_2_3;
        }
        
        private void DisposeControllers()
        {
            _task_2_1.onClick.RemoveAllListeners();
        }
        
        protected override void OnDispose()
        {
            DisposeControllers();
        }
    }
}