using UnityEngine;

namespace My_Game.Scripts
{
    public class AudioWeapon : MonoBehaviour
    {
        [SerializeField] private AudioClip audioClip;
        [SerializeField] private AudioSource audioSource;
        
        public void PlaySound()
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}