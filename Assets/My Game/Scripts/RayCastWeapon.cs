using SO;
using UnityEngine;

namespace My_Game.Scripts
{
    public class RayCastWeapon : MonoBehaviour
    {
        [SerializeField] private DataWeapon dataWeapon;
        [SerializeField] private Transform pointFire;
        
        [SerializeField] private float fireRate;
        private InputUser _inputUser;
        private float _nextFire;
        private bool _initialized;

        public void Init(InputUser user)
        {
            _inputUser = user;
            Debug.Log(_inputUser.name);
            _initialized = true;
            Subscribe();
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
        }


        private void Update()
        {
            if (!dataWeapon.isAutomatic || !_initialized) return;
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
                Shoot();
            }
        }

        private void Shoot()
        {
            var center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            var ray = Camera.main.ScreenPointToRay(center);
            if (Physics.Raycast(pointFire.position, ray.direction, out RaycastHit hit))
            {
                Debug.Log(hit.transform.name);
            }
        }

        private void OnDisable()
        {
            if (_initialized)
            {
                _inputUser.OnFireStarted -= InputUserOnOnFireStarted;
            }
        }
    }
}