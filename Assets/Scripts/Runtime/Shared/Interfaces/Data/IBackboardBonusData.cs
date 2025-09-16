namespace Assets.Scripts.Runtime.Shared.Interfaces.Data
{
    public interface IBackboardBonusData
    {
        public float NoBonusChance { get; }
        public float CommonBonusChance { get; }
        public float RareBonusChance { get; }
        public float VeryRareBonusChance { get; }
        public float MinBonusInterval { get; }
        public float MaxBonusInterval { get; }
    }
}