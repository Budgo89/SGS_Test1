using Controllers;
using UnityEngine;

namespace Task_2_3
{
    public class CameraController : BaseController
    {
        private readonly GameObject _plaers;
        private readonly Vector3 _cameraPosition;
        private Camera _camera;

        
        public CameraController(GameObject plaers, Vector3 cameraPosition)
        {
            _plaers = plaers;
            _cameraPosition = cameraPosition;
            _camera = Camera.main;
        }

        public void UpDate()
        {
            _camera.transform.position = _plaers.transform.position + _cameraPosition;
        }
    }
}