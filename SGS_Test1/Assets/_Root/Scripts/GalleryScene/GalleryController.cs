using System;
using System.Collections.Generic;
using Controllers;
using Models;
using MonoBehaviours;
using Profile;
using Tool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GalleryScene
{
    public class GalleryController: BaseController
    {
        private const int Counts = 66;
        private const int StartCounts = 6;
        
        private readonly ResourcePath _resourcePath;
        private readonly ProfilePlayers _profilePlayer;
        private readonly GalleryView _galleryView;
        private readonly string _url;
        private readonly Camera _mainCamera;
        private readonly SavePictureScene _savePictureScene;

        private List<PictureItem> _pictureItems = new List<PictureItem>();

        private PictureLoader _pictureLoader = new PictureLoader();

        public GalleryController(ProfilePlayers profilePlayer, GalleryView galleryView, string addressContentImage,
            string url, Camera mainCamera, SavePictureScene savePictureScene)
        {
            _profilePlayer = profilePlayer;
            _galleryView = galleryView;
            _url = url;
            _mainCamera = mainCamera;
            _savePictureScene = savePictureScene;
            _resourcePath = new ResourcePath(addressContentImage);
            AddContent();
            SubscribeButton();
        }

        private void SubscribeButton()
        {
            foreach (var pictureItem in _pictureItems)
            {
                var id = pictureItem._id;
                pictureItem._puttonPicture.onClick.AddListener(()=> OnButtonPictureClick(id));
            }
        }

        private void OnButtonPictureClick(int id)
        {
            var picture = _pictureItems.Find(x => x._id == id);
            _savePictureScene.SavePicture();
            _savePictureScene.Picture = picture.GetSprite();
            _profilePlayer.CurrentState.Value = GameState.Loading;
        }
        
        private void AddContent()
        {
            for (int i = 1; i <= Counts; i++)
            {
                var url = _url + i + ".jpg";
                var contentImageView = LoadView(_galleryView.Content);
                _pictureItems.Add(new PictureItem(i, url, contentImageView));
            }
        }
        
        private ContentImageView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);
            
            return objectView.GetComponent<ContentImageView>();
        }

        public void Update()
        {
            foreach (var pictureItem in _pictureItems)
            {
                if (!pictureItem.IsPictureLoader())
                {
                    if (pictureItem.GetRectTransform() == null)
                        return;
                    if (pictureItem.GetRectTransform().IsVisibleFrom(_mainCamera))
                    {
                        _pictureLoader.GetRemoteSpritePicture(pictureItem.GetURL(), pictureItem);
                        pictureItem.SetIsPictureLoader();
                    }
                }
            }
        }
        
        protected override void OnDispose()
        {
            DisposeControllers();
        }

        private void DisposeControllers()
        {
            foreach (var picture in _pictureItems)
            {
                picture._contentImageView.ImageButton.onClick.RemoveAllListeners();
            }
        }
    }
}