using UnityEngine;

namespace Assets.Scripts.Runtime.Shared.Constants
{
    public static class GameConstants
    {
        public readonly static float BasketRadius = 0.3f;
        public readonly static float MissStrongDistance = 2.0f;
        public readonly static float MissWeakDistance = 1.0f;
        public readonly static float MinFreeThrowLineDistance = -4.0f;
        public readonly static float MinShotTimeToTarget = 1.0f;
        public readonly static float MaxShotTimeToTarget = 2.0f;
        public readonly static float ClampFactor = 6.0f;
        public readonly static int RandomEvenOdd = (Random.value < 0.5f ? -1 : 1);
    }
}