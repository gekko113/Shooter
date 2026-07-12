using UnityEngine;

namespace My_Game.Scripts
{
    public class CharacterStart : MonoBehaviour
    {
        
        [SerializeField] private GameObject characterPrefab;
        [SerializeField] private Transform spawnPoint;
        private CharacterJump _characterJump;
        private CharacterMovementBasedOnCameraRotation _characterMovementBasedOnCameraRotation;
        private WeaponRaiseHandler _weaponRiseHandler;
        private SwitchWeapon _switchWeapon;
        private DropWeapon _dropWeapon;
        private InputUser _inputUser;
        
        
        public void Init(InputUser inputUser)
        {
            _inputUser = inputUser;
            var character = Instantiate(characterPrefab, spawnPoint.position, Quaternion.identity);
            _characterJump = character.GetComponent<CharacterJump>();
            _characterMovementBasedOnCameraRotation = character.GetComponent<CharacterMovementBasedOnCameraRotation>();
            _weaponRiseHandler = character.GetComponent<WeaponRaiseHandler>();
            _switchWeapon = character.GetComponent<SwitchWeapon>();
            _dropWeapon = character.GetComponent<DropWeapon>();
            _characterMovementBasedOnCameraRotation.Init(_inputUser);
            _characterJump.Init(_inputUser);
            _weaponRiseHandler.Init(_inputUser);
            _switchWeapon.Init(_inputUser);
            _dropWeapon.Init(_inputUser);   
        }
    }
}