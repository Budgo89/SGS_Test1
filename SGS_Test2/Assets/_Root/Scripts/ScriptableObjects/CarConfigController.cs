using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CarConfigController", menuName = "SGS/CarConfigController", order = 0)]
    public class CarConfigController : ScriptableObject
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] [Range(0.001f, 0.2f)] private float _rotation = 0.1f;
        [SerializeField] [Range(10f, 120f)] private  float _moveSpeedMax = 60f;
        [SerializeField] [Range(-20f, -1f)] private float _moveSpeedMin = 60f;
        [SerializeField] [Range(0.2f, 0.5f)] private float _rotationMax = 0.5f;
        
        public float MoveSpeed => _moveSpeed;
        public float Rotation => _rotation;
        public float MoveSpeedMax => _moveSpeedMax;
        public float MoveSpeedMin => _moveSpeedMin;
        public float RotationMax => _rotationMax;
    }
}