using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "DataWeapon", menuName = "SO/DataWeapon", order = 0)]
    public class DataWeapon : ScriptableObject
    {
        public WeaponType type;
        public bool isAutomatic;
        public GameObject prefab;
        public Sprite sprite;
        public float amountAmmoInMagazine;
        public float ammountAmmoMax;
    }

    public enum WeaponType
    {
        Main = 0,
        Secondary = 1,
        Melee = 2
    }
}