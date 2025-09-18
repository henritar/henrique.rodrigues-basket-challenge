using Assets.Scripts.Runtime.Shared.Interfaces.Data;
using UnityEngine;

namespace Assets.Scripts.Runtime.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New BackboardBonusData", menuName = "Scriptable Objects/Data/BackboardBonusData", order = 2)]
    public class SO_BackboardBonusData : ScriptableObject, IBackboardBonusData
    {
        [SerializeField] private float _noBonusChance = 0.45f;
        [SerializeField] private float _commonBonusChance = 0.3f;
        [SerializeField] private float _rareBonusChance = 0.15f;
        [SerializeField] private float _veryRareBonusChance = 0.1f;
        [SerializeField] private float _minBonusInterval = 2.0f;
        [SerializeField] private float _maxBonusInterval = 5.0f;

        float IBackboardBonusData.NoBonusChance => _noBonusChance;

        float IBackboardBonusData.CommonBonusChance => _commonBonusChance;

        float IBackboardBonusData.RareBonusChance => _rareBonusChance;

        float IBackboardBonusData.VeryRareBonusChance => _veryRareBonusChance;

        float IBackboardBonusData.MinBonusInterval => _minBonusInterval;

        float IBackboardBonusData.MaxBonusInterval => _maxBonusInterval;
    }
}