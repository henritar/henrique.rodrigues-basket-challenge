using Assets.Scripts.Runtime.Shared.Interfaces.Data;

namespace Assets.Scripts.Runtime.Shared.Interfaces.UI
{
    public interface IInputBarController 
    {
        void SetPower(float powerPercent);
        void SetZonePosition(IShotResultData shotData);
        void EnableInputBar(bool isEnabled);
    }
}