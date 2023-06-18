using System.Collections;
using Controllers;
using Profile;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GalleryScene
{
    public class LoadingGalleryController : BaseController
    {
        private readonly ProfilePlayers _profilePlayer;
        private readonly GalleryView _galleryView;
        private readonly CorotinesController _corotinesController;
        private readonly string _sceneTitles;
        
        private Slider _progressBar;
        private GameObject _scrollView;
        private Coroutine _coroutine;

        public LoadingGalleryController(ProfilePlayers profilePlayer, GalleryView galleryView, CorotinesController corotinesController, 
            string sceneTitles)
        {
            _profilePlayer = profilePlayer;
            _galleryView = galleryView;
            _corotinesController = corotinesController;
            _sceneTitles = sceneTitles;
            
            AddElement();
            StartProgressBar();
        }

        private void AddElement()
        {
            _progressBar = _galleryView.ProgressBar;
            _scrollView = _galleryView.ScrollView;
        }

        private void StartProgressBar()
        {
            if (!_progressBar.IsActive())
                _progressBar.gameObject.SetActive(true);
            if (_scrollView.gameObject.activeSelf)
                _scrollView.SetActive(false);
            
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
    }
}