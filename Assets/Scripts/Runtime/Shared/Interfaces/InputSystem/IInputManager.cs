namespace Assets.Scripts.Runtime.Shared.Interfaces.InputSystem
{
    public interface IInputManager<TInputHandler> where TInputHandler : IInputHandler
    {
        public void HandlePlainClick();
        public void SetCurrentInputHandler(TInputHandler handler, bool enableActions = true);
        public void EnableAction();
        public void DisableAction();
    }
}