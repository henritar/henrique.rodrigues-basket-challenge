using Assets.Scripts.Runtime.Shared.Interfaces.Interactables;
using UnityEngine;

namespace Assets.Scripts.Runtime.Gameplay.Interactables
{
    public class BasketPoint : MonoBehaviour, IBasketPoint
    {
        public Vector3 Position => transform.position;
    }
}