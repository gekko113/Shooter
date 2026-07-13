using System;
using UnityEngine;

namespace My_Game.Scripts
{
    public class GroundHandle : MonoBehaviour
    {
        public event Action<bool> OnGround;
        [SerializeField] private Transform point;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask groundMask;
        private bool _isGrounded;

        public bool ReturnGroundStatus()
        {
            return _isGrounded;
        }
        private void Update()
        {
            CheckGround();
        }
        

        private void CheckGround()
        {
            var newGrounded = Physics.CheckSphere(point.position, radius, groundMask);
            if (newGrounded == _isGrounded) return;
            _isGrounded = newGrounded;
            OnGround?.Invoke(_isGrounded);
        }
    }
}