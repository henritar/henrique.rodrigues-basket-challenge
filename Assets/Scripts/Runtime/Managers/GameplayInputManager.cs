using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces;
using Assets.Scripts.Runtime.Shared.Interfaces.InputSystem;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
using UnityEditor;
#elif UNITY_IOS || UNITY_ANDROID
using UnityEngine.InputSystem;
#endif

namespace Assets.Scripts.Runtime.Managers
{
    public class GameplayInputManager : BaseManager, IGameplayInputManager
    {
        private IGameplayInputReader _gameplayInputReader;
        private IGameplayInputHandler _currentInputHandler;

        public GameplayInputManager(IGameplayInputReader inputReader)
        {
            _gameplayInputReader = inputReader;
        }

        public override void Initialize()
        {
            if (_isInitialized)
            {
                Debug.LogWarning("IGameplayInputReader is already initialized. Skipping initialization.");
                return;
            }

            _gameplayInputReader.PlainClicked += HandlePlainClick;
            _gameplayInputReader.ClickHolded += HandleHoldClick;
            _gameplayInputReader.ClickRelease += HandleReleaseClick;

            _isInitialized = true;
        }

        public void SetCurrentInputHandler(IGameplayInputHandler handler, bool enableActions = true)
        {
            _currentInputHandler = handler;

            if (enableActions)
            {
                EnableAction();
            }
            else
            {
                DisableAction();
            }
        }

        public void DisableAction()
        {
            _gameplayInputReader.DisableActions();
        }

        public void EnableAction()
        {
            _gameplayInputReader.EnableActions();
        }

        public void HandlePlainClick()
        {
            HandlePlainClickAsync().Forget();
        }

        public void HandleHoldClick()
        {
            HandleHoldClickAsync().Forget();
        }

        public void HandleReleaseClick()
        {
            _currentInputHandler?.HandleReleaseClick();
        }

        private async UniTask HandleHoldClickAsync()
        {
            await UniTask.NextFrame();

            if (IsPointerOverUI())
                return;

            _currentInputHandler?.HandleHoldClick();
        }

        private async UniTask HandlePlainClickAsync()
        {
            await UniTask.NextFrame();

            if (IsPointerOverUI())
                return;

            _currentInputHandler?.HandlePlainClick();
        }

        private bool IsPointerOverUI()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            return EventSystem.current.IsPointerOverGameObject();

#elif UNITY_IOS || UNITY_ANDROID
    if (Touchscreen.current != null && Touchscreen.current.touches.Count > 0)
    {
        var touchId = Touchscreen.current.touches[0].touchId.ReadValue();
        return EventSystem.current.IsPointerOverGameObject(touchId);
    }
    return false;

#else
    return EventSystem.current.IsPointerOverGameObject();
#endif
        }

        protected override void OnDestroying()
        {
            _gameplayInputReader.PlainClicked -= HandlePlainClick;
            _gameplayInputReader.ClickHolded -= HandleHoldClick;
            _gameplayInputReader.ClickRelease -= HandleReleaseClick;
            _isInitialized = false;
        }
    }
}