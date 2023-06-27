using UnityEngine;

namespace View
{
    public class CubeView : MonoBehaviour
    {
        [SerializeField] private GameObject _cube;
        [SerializeField] [Range(0.1f, 1f)] private float _speedRotational = 0.4f;

        public GameObject Cube => _cube;
        public float SpeedRotational => _speedRotational;
    }
}