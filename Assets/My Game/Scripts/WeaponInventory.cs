using SO;
using UnityEngine;

namespace My_Game.Scripts
{
    public class WeaponInventory : MonoBehaviour
    {
        [SerializeField] private AudioWeapon audioWeapon;

        public DataWeapon[] dataWeapons;
        public GameObject[] weaponPrefabs;
        public int CurrentIndex { get; private set; } = -1;

        public void AddWeapon(DataWeapon dataWeapon)
        {
            if (dataWeapons[(int)dataWeapon.type] != null) return;
            dataWeapons[(int)dataWeapon.type] = dataWeapon;
        }

        public void RegisterPrefabs(DataWeapon dataWeapon, GameObject prefab)
        {
            if (weaponPrefabs[(int)dataWeapon.type] != null) return;
            weaponPrefabs[(int)dataWeapon.type] = prefab;
        }

        public DataWeapon RemoveWeapon(int index)
        {
            if (index < 0 || index >= dataWeapons.Length) return null;
            DataWeapon removedWeapon = dataWeapons[index];
            dataWeapons[index] = null;
            Destroy(weaponPrefabs[index]);
            weaponPrefabs[index] = null;
            return removedWeapon;
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

            CurrentIndex = index;
        }
    }
}