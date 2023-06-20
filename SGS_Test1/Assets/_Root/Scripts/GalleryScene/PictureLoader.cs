using System.Threading;
using System.Threading.Tasks;
using Models;
using UnityEngine;
using UnityEngine.Networking;

namespace GalleryScene
{
    public class PictureLoader
    {
        public async Task GetRemoteSpritePicture(string url, PictureItem pictureItem)
        {
            using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(url))
            {
                var open = request.SendWebRequest();
                while (open.isDone == false)
                    await Task.Delay(100);

                if (request.isNetworkError || request.isHttpError)
                {
                    Debug.Log($"{request.error}, URL:{request.url}");
                }
                var content = DownloadHandlerTexture.GetContent(request);
                pictureItem.SetImage(СreateSprite(content));
            }
        }

        private Sprite СreateSprite(Texture2D content)
        {
            var sprite = Sprite.Create(content, new Rect(0.0f, 0.0f, content.width, content.height),
                new Vector2(0.5f, 0.5f), 100.0f);
            return sprite;
        }
    }
}