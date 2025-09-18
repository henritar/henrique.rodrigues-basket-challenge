using Assets.Scripts.Runtime.Shared.Interfaces.MVP;
using System;

namespace Assets.Scripts.Runtime.Shared.Interfaces.UI
{
    public interface ITimerMenuView : IBaseView
    {
        void SetTimerValues(int[] values);
        IObservable<int> OnTimerValueChanged { get; }
    }
}