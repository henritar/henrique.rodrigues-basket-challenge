using Assets.Scripts.Runtime.Shared.Interfaces.Data;
using UnityEngine;

namespace Assets.Scripts.Runtime.ScriptableObjects
{

    [CreateAssetMenu(fileName = "New TimerData", menuName = "Scriptable Objects/Data/TimerData", order = 3)]
    public class SO_TimerData : ScriptableObject, ITimerData
    {
        [SerializeField] private int[] _initialTimerValues = new int[] { 30, 60, 90 };
        public int[] InitialTimerValues => _initialTimerValues;
    }
}