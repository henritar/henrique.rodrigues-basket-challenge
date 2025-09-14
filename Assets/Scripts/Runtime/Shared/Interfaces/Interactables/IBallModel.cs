using Assets.Scripts.Runtime.Shared.Interfaces.MVP;
using UnityEngine;

namespace Assets.Scripts.Runtime.Shared.Interfaces.Interactables
{
    public interface IBallModel : IBaseModel
    {
        Vector3 StartPosition { get; set; }
    }
}