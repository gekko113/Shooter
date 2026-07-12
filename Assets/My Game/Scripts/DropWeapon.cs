using SO;
using UnityEngine;

namespace My_Game.Scripts
{
    public class DropWeapon : MonoBehaviour
    {
        [SerializeField] private WeaponInventory weaponInventory;
        [SerializeField] private Transform dropPosition;
        
        
        private InputUser _inputUser;
        
        public void Init(InputUser inputUser)
        {
            _inputUser = inputUser;
            _inputUser.OnDrop += InputUserOnOnDrop;
        }

        private void InputUserOnOnDrop()
        {
            DataWeapon droppedWeapon = weaponInventory.RemoveWeapon(weaponInventory.CurrentIndex);
            Instantiate(droppedWeapon.prefab, dropPosition.position, Quaternion.identity);
        }

        private void OnDisable()
        {
            _inputUser.OnDrop -= InputUserOnOnDrop;
        }
    }
}