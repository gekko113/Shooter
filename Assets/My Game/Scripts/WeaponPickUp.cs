using SO;
using UnityEngine;

namespace My_Game.Scripts
{
    public class WeaponPickUp : MonoBehaviour
    {
        [SerializeField] private DataWeapon dataWeapon;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            other.GetComponent<WeaponInventory>().AddWeapon(dataWeapon);
            other.GetComponent<WeaponRaiseHandler>().WeaponPickUp(dataWeapon);
            Destroy(gameObject);
        }
    }
}