using Assets.Scripts.Runtime.Shared.Interfaces.InputSystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

namespace Assets.Scripts.Runtime.ScriptableObjects.InputSystem
{
    [CreateAssetMenu(fileName = "New Gameplay Input Reader", menuName = "Scriptable Objects/Input System/Gameplay Input Reader")]
    public class SO_GameplayInputReader : ScriptableObject, IGameplayActions, IGameplayInputReader
    {
        public event UnityAction PlainClicked;
        public event UnityAction ClickHolded;
        public event UnityAction ClickRelease;

        public InputSystem_Actions inputActions;

        private bool _isAiming;

        private Vector2 _lastPointerPosition;
        public Vector2 PointerPosition => _lastPointerPosition;

        public void EnableActions()
        {
            if (inputActions == null)
            {
                inputActions = new InputSystem_Actions();
                inputActions.Gameplay.SetCallbacks(this);
            }
            inputActions.Gameplay.Enable();
        }

        public void DisableActions()
        {
            inputActions.Gameplay.Disable();
        }

        public void OnPlainClick(InputAction.CallbackContext context)
        {
            if (context.ReadValue<float>() > 0f && context.performed)
            {
                PlainClicked?.Invoke();
            }
        }

        public void OnPrepareShoot(InputAction.CallbackContext context)
        {
            if (context.started) // só quando começar a segurar
            {
                _isAiming = true;
                ClickHolded?.Invoke();
            }
        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            if (context.canceled && _isAiming) // só ao soltar depois de segurar
            {
                _isAiming = false;
                ClickRelease?.Invoke();
            }
        }

        public void OnScreenPos(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _lastPointerPosition = context.ReadValue<Vector2>();
            }
        }
    }
}