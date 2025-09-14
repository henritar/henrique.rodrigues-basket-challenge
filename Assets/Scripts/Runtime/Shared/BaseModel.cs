using Assets.Scripts.Runtime.Shared.Interfaces.MVP;

namespace Assets.Scripts.Runtime.Shared
{
    public abstract class BaseModel : IBaseModel
    {
        private bool _isDisposed = false;

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            Dispose(true);

            _isDisposed = true;
        }
        protected virtual void Dispose(bool disposing) { }
    }
}