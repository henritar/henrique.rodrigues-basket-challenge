using Assets.Scripts.Runtime.Shared.Interfaces.MVP;
using VContainer.Unity;

namespace Assets.Scripts.Runtime.Shared
{
    public abstract class BasePresenter<TModel, TView> : IInitializable, IBasePresenter where TModel : IBaseModel where TView : IBaseView
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

        public void Initialize()
        {
            if (_isActive || _isDisposed) return;

            SubscribeToEvents();
            OnInitialize();

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

        protected virtual void OnInitialize() { }

        protected virtual void Cleanup() { }

        protected abstract void SubscribeToEvents();
        protected abstract void UnsubscribeFromEvents();
    }
}