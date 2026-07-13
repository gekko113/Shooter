using UnityEngine;

namespace My_Game.Scripts
{
    public class VFXWeaponHandler : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particleSystemPrefab;
        [SerializeField] private Transform positionVFX;
        [SerializeField] private float lifeTime;
        
        
        
        public void VFXApply()
        {
            var prefab = Instantiate(particleSystemPrefab, positionVFX.position, positionVFX.rotation, positionVFX);
            Destroy(prefab.gameObject, lifeTime);
        }
        
    }
}