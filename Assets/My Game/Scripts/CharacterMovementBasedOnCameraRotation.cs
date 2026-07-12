using Unity.Cinemachine;
using UnityEngine;

namespace My_Game.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovementBasedOnCameraRotation : MonoBehaviour
    {

        
        [SerializeField] private CinemachineCamera cameraTransform;
        [SerializeField] private float velocity;
    
        private CharacterController _controller;
        private Vector3 _moveDirection;
        private InputUser _inputUser;

        public void Init(InputUser inputUser)
        {
            _inputUser = inputUser;
        }
        private void Start()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            _moveDirection = new Vector3(_inputUser.Direction.x, 0f, _inputUser.Direction.y).normalized;
            var move = GetCameraForward() * _moveDirection.z + GetCameraRight() * _moveDirection.x;
            move = move.normalized;
            _controller.Move(move * (velocity * Time.deltaTime));
        }

        private Vector3 GetCameraForward()
        {
            var cameraForward = cameraTransform.transform.forward;
            cameraForward.y = 0;
            return cameraForward;
        }

        private Vector3 GetCameraRight()
        {
            var cameraRight = cameraTransform.transform.right;
            cameraRight.y = 0;
            return cameraRight;
        }
    }
}
