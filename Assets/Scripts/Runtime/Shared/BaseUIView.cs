using Assets.Scripts.Runtime.Shared.Interfaces.MVP;
using UnityEngine;

namespace Assets.Scripts.Runtime.Shared
{
    public class BaseUIView : MonoBehaviour, IBaseView
    {
        public bool IsActive => gameObject.activeInHierarchy;

        public void Show()
        {
            gameObject.SetActive(true);
        }
        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Dispose()
        {
            Destroy(this);
        }
    }
}