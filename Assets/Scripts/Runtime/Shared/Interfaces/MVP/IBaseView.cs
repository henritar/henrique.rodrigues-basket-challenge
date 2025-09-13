using System;

namespace Assets.Scripts.Runtime.Shared.Interfaces.MVP
{
    public interface IBaseView : IDisposable
    {
        bool IsActive { get; }
        void Show();
        void Hide();
    }
}