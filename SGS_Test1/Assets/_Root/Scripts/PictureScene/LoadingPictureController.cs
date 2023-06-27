using System.Collections;
using Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PictureScene
{
    public class LoadingPictureController: BaseController
    {
        private readonly PictureSceneView _pictureSceneView;
        private readonly CorotinesController _corotinesController;
        private readonly string _sceneTitles;
        
        private Slider _progressBar;
        private GameObject _pictureGameObject;
        private Coroutine _coroutine;

        
        public LoadingPictureController(PictureSceneView pictureSceneView, CorotinesController corotinesController, string sceneTitles)
        {
            _pictureSceneView = pictureSceneView;
            _corotinesController = corotinesController;
            _sceneTitles = sceneTitles;
            AddElement();
            StartProgressBar();
        }
        
        private void AddElement()
        {
            _progressBar = _pictureSceneView.ProgressBar;
            _pictureGameObject = _pictureSceneView.PictureGameObject;
        }

        private void StartProgressBar()
        {
            if (!_progressBar.IsActive())
                _progressBar.gameObject.SetActive(true);
            if (_pictureGameObject.gameObject.activeSelf)
                _pictureGameObject.SetActive(false);
            
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