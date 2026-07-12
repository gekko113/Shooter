using SO;
using UnityEngine;

namespace My_Game.Scripts
{
    public class WeaponInventory : MonoBehaviour
    {
        public DataWeapon[] dataWeapons;
        public GameObject[] weaponPrefabs;
        private float _currentIndex = -1;

        public void AddWeapon(DataWeapon dataWeapon)
        {
            if (dataWeapons[(int)dataWeapon.type] != null) return;
            dataWeapons[(int)dataWeapon.type] = dataWeapon;
        }

        public void RegisterPrefabs(DataWeapon dataWeapon, GameObject prefab)
        {
            weaponPrefabs[(int)dataWeapon.type] = prefab;
        }

        public void RemoveWeapon(DataWeapon dataWeapon)
        {
            dataWeapons[(int)dataWeapon.type] = null;
            weaponPrefabs[(int)dataWeapon.type] = null;
        }
    
        public void SwitchWeapon(int index)
        {
            if (index < 0 || index >= weaponPrefabs.Length)
                return;
            if (weaponPrefabs[index] == null) return;
            for (int i = 0; i < weaponPrefabs.Length; i++)
            {
                if (weaponPrefabs[i] != null)
                {
                    weaponPrefabs[i].SetActive(i == index);
                }
            }
            _currentIndex = index;
        }
    }
}