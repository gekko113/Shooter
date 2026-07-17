using SO;
using UnityEngine;

namespace My_Game.Scripts
{
    public class WeaponRaiseHandler : MonoBehaviour
    {
        [SerializeField] private WeaponInventory weaponInventory;
        [SerializeField] private Transform slot;
        [SerializeField] private SetupIK setupIK;

        private InputUser _inputUser;

        public void Init(InputUser inputUser)
        {
            _inputUser = inputUser;
        }

        public void WeaponPickUp(DataWeapon obj)
        {
            weaponInventory.AddWeapon(obj);
            var prefab = Instantiate(obj.prefab, slot.position, slot.rotation, slot);

            prefab.GetComponent<BoxCollider>().enabled = false;
            prefab.transform.localPosition = Vector3.zero;
            prefab.transform.localRotation = Quaternion.identity;
            prefab.GetComponent<RayCastWeapon>().Init(_inputUser);
            if (prefab.TryGetComponent<WeaponRigTargets>(out var weaponTargets))
            {
                if (setupIK != null)
                {
                    setupIK.BindWeaponIK(weaponTargets);
                }
                else
                {
                    Debug.LogWarning($"[{nameof(WeaponRaiseHandler)}] SetupIK не назначен в инспекторе!");
                }
            }

            weaponInventory.RegisterPrefabs(obj, prefab);
            weaponInventory.SwitchWeapon((int)obj.type);
        }
    }
}