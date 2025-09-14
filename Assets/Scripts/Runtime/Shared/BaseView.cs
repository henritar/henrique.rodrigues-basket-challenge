using Assets.Scripts.Runtime.Shared.Interfaces.MVP;
using UnityEngine;

namespace Assets.Scripts.Runtime.Shared
{
    public abstract class BaseView : MonoBehaviour, IBaseView
    {
        public Transform Transform => transform;
        public virtual bool IsActive => gameObject.activeInHierarchy;

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Dispose()
        {
            Destroy(this);
        }
    }
}