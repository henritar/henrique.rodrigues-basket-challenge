﻿using Assets.Scripts.Runtime.Shared.Interfaces.MVP;
using UnityEngine.Events;

namespace Assets.Scripts.Runtime.Shared.Interfaces.UI
{
    public interface IRewardMenuView : IBaseView
    {
        void SetFinalScore(int finalScore);
        void SetPlayAgainAction(UnityAction action);
        void SetMainMenuAction(UnityAction action);
    }
}