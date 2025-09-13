using System;

namespace Assets.Scripts.Runtime.Shared.Interfaces.MVP
{
    public interface IBasePresenter : IDisposable
    {
        void Activate();
    }
}