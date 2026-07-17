using DG.Tweening;
using SO;
using UnityEngine;
using UnityEngine.Events;

namespace My_Game.Scripts
{
    public class RayCastWeapon : MonoBehaviour
    {
        public UnityEvent onShoot;
        [SerializeField] private DataWeapon dataWeapon;
        [SerializeField] private Transform pointFire;
        [SerializeField] private Vector3 recoil;

        [SerializeField] private Transform weaponTransform;
        private Vector3 _originalWeaponRotation;

        [SerializeField] private float fireRate;
        private InputUser _inputUser;
        private float _nextFire;
        private bool _initialized;
        private float _currentBullets;
        private float _maxBullets;


        public void Init(InputUser user)
        {
            _inputUser = user;
            _initialized = true;
            Subscribe();
            _currentBullets = dataWeapon.amountAmmoInMagazine;
            _maxBullets = dataWeapon.ammountAmmoMax;
        }

        private void RecoilApply()
        {
            var recoilSequence = DOTween.Sequence();
            weaponTransform.DOKill();
            recoilSequence.Append(weaponTransform.DOLocalRotate(recoil, 0.05f).SetEase(Ease.OutQuad));
            recoilSequence.Append(weaponTransform.DOLocalRotate(_originalWeaponRotation,  0.05f).SetEase(Ease.OutQuad));
        }
        

        private void Awake()
        {
            _originalWeaponRotation = weaponTransform.localEulerAngles;
        }

        private void OnEnable()
        {
            if (_initialized)
            {
                Subscribe();
            }
        }

        private void Subscribe()
        {
            _inputUser.OnFireStarted += InputUserOnOnFireStarted;
            _inputUser.OnReload += ReloadWeapon;
        }


        private void Update()
        {
            if (!dataWeapon.isAutomatic || !_initialized) return;
            if (_currentBullets <= 0) return;
            if (_inputUser.IsFirePressed)
            {
                _nextFire -= Time.deltaTime;
                if (_nextFire <= 0f)
                {
                    Shoot();
                    _nextFire = fireRate;
                }
            }
            else
            {
                _nextFire = 0f;
            }
        }

        private void InputUserOnOnFireStarted()
        {
            if (!dataWeapon.isAutomatic)
            {
                if (_currentBullets <= 0) return;
                Shoot();
            }
        }

        private void Shoot()
        {
            var center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            var ray = Camera.main.ScreenPointToRay(center);
            if (Physics.Raycast(pointFire.position, ray.direction, out RaycastHit hit))
            {
                onShoot?.Invoke();
                RecoilApply();
                _currentBullets--;
            }
        }

        private void ReloadWeapon()
        {
            var maxBulletsInMagazine = dataWeapon.amountAmmoInMagazine;
            var needed = maxBulletsInMagazine - _currentBullets;
            if (needed <= 0) return;
            var delta = Mathf.Min(needed, _maxBullets);
            _maxBullets -= delta;
            _currentBullets += delta;
        }

        private void OnDisable()
        {
            if (_initialized)
            {
                _inputUser.OnFireStarted -= InputUserOnOnFireStarted;
                _inputUser.OnReload -= ReloadWeapon;
            }
        }
    }
}