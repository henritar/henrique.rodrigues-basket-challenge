using Assets.Scripts.Runtime.Shared.Interfaces.MVP;
using System.Threading;
using UnityEngine;

namespace Assets.Scripts.Runtime.Shared
{
    public abstract class BasePresenter<TModel, TView> : IBasePresenter where TModel : IBaseModel where TView : IBaseView
    {
        protected TModel Model { get; private set; }
        protected TView View { get; private set; }

        private bool _isActive = false;
        private bool _isDisposed = false;

        public BasePresenter(TModel model, TView view)
        {
            this.Model = model;
            this.View = view;
        }

        public void Activate()
        {
            if (_isActive || _isDisposed) return;

            SubscribeToEvents();
            Initialize();

            _isActive = true;
        }

        public void Dispose()
        {
            if (_isDisposed) return;

            UnsubscribeFromEvents();
            Model.Dispose();
            View.Dispose();
            Cleanup();

            Model = default;
            View = default;

            _isActive = false;
            _isDisposed = true;
        }

        protected virtual void Initialize() { }

        protected virtual void Cleanup() { }

        protected abstract void SubscribeToEvents();
        protected abstract void UnsubscribeFromEvents();
    }
}