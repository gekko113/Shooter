using UnityEngine;

namespace My_Game.Scripts
{
    public class CharacterJump : MonoBehaviour
    {
        [SerializeField] private GravityHandle gravityHandle;
        [SerializeField] private GroundHandle groundHandle;
        [SerializeField] private float jumpHeight;
        private InputUser _inputUser;
    
        private bool _isGrounded;

        public void Init(InputUser inputUser)
        {
            _inputUser = inputUser;
            _inputUser.OnJump += Jump;
        }

        private void OnEnable()
        {
            groundHandle.OnGround += GroundHandleOnOnGround;
        }

        private void GroundHandleOnOnGround(bool isGrounded)
        {
            _isGrounded = isGrounded;
        }
    
        private void Jump()
        {
            if (_isGrounded)
            {
                gravityHandle.VelocityY = Mathf.Sqrt(jumpHeight * -2f * gravityHandle.GravityScale);
            }
        }
    
        private void OnDisable()
        {
            _inputUser.OnJump -= Jump;
            groundHandle.OnGround -= GroundHandleOnOnGround;
        }
    }
}