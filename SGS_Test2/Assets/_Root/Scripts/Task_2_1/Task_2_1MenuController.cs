using Controllers;
using Profile;
using ScriptableObjects;
using Tool;
using UnityEngine;
using UnityEngine.UI;

namespace Task_2_1
{
    public class Task_2_1MenuController : BaseController
    {
        private readonly ResourcePath _resourcePath;
        
        private readonly ProfilePlayers _profilePlayer;

        private MenuTask_2View _menuTask2View;
        private Button _menuTask_2Button;

        public Task_2_1MenuController(ProfilePlayers profilePlayer, Transform placeForUi, Task_2_1AddressPrefabs task21AddressPrefabs)
        {
            _profilePlayer = profilePlayer;

            _resourcePath = new ResourcePath(task21AddressPrefabs.MenuTask_2_1);
            _menuTask2View = LoadView(placeForUi);
            
            AddButton();
            SubscribeButton();
        }

        private void SubscribeButton()
        {
            _menuTask_2Button.onClick.AddListener(OnMenuTask_2ButtonClick);
        }

        private void OnMenuTask_2ButtonClick() => _profilePlayer.CurrentState.Value = GameState.Menu;
        
        private void AddButton()
        {
            _menuTask_2Button = _menuTask2View.MenuTask_2_1Button;
        }

        private MenuTask_2View LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);
            
            return objectView.GetComponent<MenuTask_2View>();
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