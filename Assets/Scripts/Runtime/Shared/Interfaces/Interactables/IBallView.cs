﻿using Assets.Scripts.Runtime.Shared.Interfaces.MVP;
using UnityEngine;

namespace Assets.Scripts.Runtime.Shared.Interfaces.Interactables
{
    public interface IBallView : IBaseView
    {
        Transform Transform { get; }
        Rigidbody Rigidbody { get; }
    }
}