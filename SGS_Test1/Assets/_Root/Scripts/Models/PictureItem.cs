using UnityEngine;
using UnityEngine.UI;

namespace Models
{
    public class PictureItem
    {
        public int _id;
        public Button _puttonPicture;
        public readonly ContentImageView _contentImageView;
        private string _url;
        private Image _image;
        private RectTransform _rectTransform;
        private bool _isPictureLoader = false;

        
        public PictureItem(int id, string url, ContentImageView contentImageView)
        {
            _id = id;
            _url = url;
            _contentImageView = contentImageView;
            _rectTransform = contentImageView.RectTransforms;
            _image = contentImageView.Images;
            _puttonPicture = contentImageView.ImageButton;
        }

        public string GetURL()
        {
            return _url;
        }

        public void SetImage(Sprite sprite)
        {
            _image.sprite = sprite;
        }
        public Sprite GetSprite()
        {
            return _image.sprite;
        }
        public RectTransform GetRectTransform()
        {
            return _rectTransform;
        }

        public void SetIsPictureLoader()
        {
            _isPictureLoader = true;
        }

        public bool IsPictureLoader()
        {
            return _isPictureLoader;
        }
    }
}