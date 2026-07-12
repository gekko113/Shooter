using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace My_Game.Scripts
{
    public class InputUser : MonoBehaviour
    {
        public Vector2 Direction { get; private set; }
        public bool IsFirePressed { get; private set; } = false;
        public event Action OnJump;
        public event Action OnFireStarted;
        public event Action OnFireCancelled;
        public event Action OnDrop;
        public event Action OnFirst;
        public event Action OnSecond;
        public event Action OnThird;
        public event Action OnReload;
        private NewMapActions _newMapActions;
        
        private void OnEnable()
        {
            _newMapActions = new NewMapActions();
            _newMapActions.Enable();
            _newMapActions.Player.Jump.started += HandleJump;
            _newMapActions.Player.Fire.started += FireOnStarted;
            _newMapActions.Player.Fire.canceled += FireOnCanceled;
            _newMapActions.Player.Drop.started += DropOnstarted;
            _newMapActions.Player._1.started += First;
            _newMapActions.Player._2.started += Second;
            _newMapActions.Player._3.started += Third;
            _newMapActions.Player.Reload.started += ReloadOnstarted;
        }

        private void ReloadOnstarted(InputAction.CallbackContext obj)
        {
            OnReload?.Invoke();
        }

        private void First(InputAction.CallbackContext obj)
        {
            OnFirst?.Invoke();
        }
        private void Second(InputAction.CallbackContext obj)
        {
            OnSecond?.Invoke();
        }
        private void Third(InputAction.CallbackContext obj)
        {
            OnThird?.Invoke();
        }

        private void DropOnstarted(InputAction.CallbackContext obj)
        {
            OnDrop?.Invoke();
        }

        private void FireOnCanceled(InputAction.CallbackContext obj)
        {
            IsFirePressed = false;
            OnFireCancelled?.Invoke();
        }

        private void FireOnStarted(InputAction.CallbackContext obj)
        {
            IsFirePressed = true;
            OnFireStarted?.Invoke();
        }

        private void HandleJump(InputAction.CallbackContext obj)
        {
            OnJump?.Invoke();
        }

        private void Update()
        {
            Direction = _newMapActions.Player.Move.ReadValue<Vector2>();
        }

        private void OnDisable()
        {
            _newMapActions.Disable();
            _newMapActions.Player.Jump.started -= HandleJump;
            _newMapActions.Player.Fire.started -= FireOnStarted;
            _newMapActions.Player.Fire.canceled -= FireOnCanceled;
            _newMapActions.Player._1.started -= First;
            _newMapActions.Player._2.started -= Second;
            _newMapActions.Player._3.started -= Third;
        }
    }
}