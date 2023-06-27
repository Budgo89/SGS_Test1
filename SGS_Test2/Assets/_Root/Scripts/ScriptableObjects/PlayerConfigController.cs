using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerConfigController", menuName = "SGS/PlayerConfigController", order = 0)]
    public class PlayerConfigController : ScriptableObject
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _jumpForce = 5f;
        [SerializeField] private LayerMask _nonGroundMask;

        public float MoveSpeed => _moveSpeed;
        public float JumpForce => _jumpForce;

        public LayerMask NonGroundMask => _nonGroundMask;
    }
}