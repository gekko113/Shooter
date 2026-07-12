using System;
using UnityEngine;

namespace My_Game.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class GravityHandle : MonoBehaviour
    {
        public event Action<float> OnChangeVelocityY;
        public float VelocityY { get; set; }
        public float GravityScale { get; set; } = -15f;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private GroundHandle groundHandle;
        private bool _isGrounded;


        private void Start()
        {
            groundHandle.OnGround += TakeGroundInfo;
        }

        private void Update()
        {
            if (_isGrounded && VelocityY < 0)
            {
                ChangeVelocityY(-2f);
            }

            ApplyGravity();
        }

        private void TakeGroundInfo(bool grounded)
        {
            _isGrounded = grounded;
        }

        private void ApplyGravity()
        {
            ChangeVelocityY(VelocityY + GravityScale * Time.deltaTime);
            characterController.Move(Vector3.up * (VelocityY * Time.deltaTime));
        }

        private void ChangeVelocityY(float newVelocityY)
        {
            VelocityY = newVelocityY;
            OnChangeVelocityY?.Invoke(VelocityY);
        }

        private void OnDisable()
        {
            groundHandle.OnGround -= TakeGroundInfo;
        }
    }
}