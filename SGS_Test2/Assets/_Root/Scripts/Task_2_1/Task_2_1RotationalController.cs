using Controllers;
using UnityEngine;
using View;

namespace Task_2_1
{
    public class Task_2_1RotationalController : BaseController
    {
        private GameObject _cube;
        private float _speedRotational;
        private Transform _transform;

        public Task_2_1RotationalController(CubeView cubeView)
        {
            _cube = cubeView.Cube;
            _speedRotational = cubeView.SpeedRotational;
            _transform = _cube.transform;
        }

        public void UpData()
        {
            _transform.Rotate(_speedRotational, _speedRotational, _speedRotational);
        }
    }
}