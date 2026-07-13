using UnityEngine;

namespace My_Game.Scripts
{
    public class AudioCharacterSteps : MonoBehaviour
    {
        [SerializeField] private CharacterMovementBasedOnCameraRotation characterMovementBasedOnCameraRotation;
        [SerializeField] private GroundHandle groundHandle;
        [SerializeField] private AudioSource audioSource;
        
        private void Update()
        {
            var isGrounded = groundHandle.ReturnGroundStatus();
            var isMoving = characterMovementBasedOnCameraRotation.ReturnMovement();
            if (isMoving && !audioSource.isPlaying && isGrounded)
            {
                audioSource.Play();
            }
            else if (isMoving && audioSource.isPlaying && !isGrounded || !isMoving && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}