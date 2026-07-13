using UnityEngine;

namespace My_Game.Scripts
{
    public class SwitchWeapon : MonoBehaviour
    {
        [SerializeField] private WeaponInventory weaponInventory;
        private InputUser _inputUser;
        
        public void Init(InputUser inputUser)
        {
            _inputUser = inputUser;
            _inputUser.OnFirst += InputUserOnOnFirst;
            _inputUser.OnSecond += InputUserOnOnSecond;
            _inputUser.OnThird += InputUserOnOnThird;
        }
        
        private void InputUserOnOnThird()
        {
            weaponInventory.SwitchWeapon(2);
        }

        private void InputUserOnOnSecond()
        {
            weaponInventory.SwitchWeapon(1);
        }

        private void InputUserOnOnFirst()
        {
            weaponInventory.SwitchWeapon(0);
        }

        private void OnDisable()
        {
            _inputUser.OnFirst -= InputUserOnOnFirst;
            _inputUser.OnSecond -= InputUserOnOnSecond;
            _inputUser.OnThird -= InputUserOnOnThird;
        }
    }
}