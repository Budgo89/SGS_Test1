using UnityEngine;

namespace MonoBehaviours
{
    public class SavePictureScene : MonoBehaviour
    {
        [SerializeField] private Sprite _picture;

        public Sprite Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }

        public void SavePicture()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}