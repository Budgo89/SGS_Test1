using System.Collections;
using Controllers;
using Profile;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class LoadingController: BaseController
    {
        private readonly ProfilePlayers _profilePlayer;
        private readonly CorotinesController _corotinesController;
        private readonly string _sceneTitles;
        private Slider _progressBar;
        private Button _galleryButton;
        private MainMenuView _mainMenuView;
        private Coroutine _coroutine;

        
        public LoadingController(ProfilePlayers profilePlayer, MainMenuView mainMenuView, CorotinesController corotinesController, string sceneTitles)
        {
            _profilePlayer = profilePlayer;
            _mainMenuView = mainMenuView;
            _corotinesController = corotinesController;
            _sceneTitles = sceneTitles;
            AddElement();
            StartProgressBar();
        }

        private void AddElement()
        {
            _progressBar = _mainMenuView.ProgressBar;
            _galleryButton = _mainMenuView.GalleryButton;
        }

        private void StartProgressBar()
        {
            if (!_progressBar.IsActive())
                _progressBar.gameObject.SetActive(true);
            if (_galleryButton.IsActive())
                _galleryButton.gameObject.SetActive(false);
            
            _coroutine =_corotinesController.StartCoroutines(LoadAsync());
        }

        IEnumerator LoadAsync()
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneTitles);

            while (!asyncLoad.isDone)
            {
                _progressBar.value = asyncLoad.progress;
                yield return null;
            }
        }
        
        protected override void OnDispose()
        {
            _corotinesController.StopCoroutines(_coroutine);
        }
    }
}