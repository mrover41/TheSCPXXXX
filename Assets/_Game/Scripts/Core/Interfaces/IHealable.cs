namespace Game.Core.Interfaces
{
    public interface IHealable
    {
        ushort Health { get; }
        ushort MaxHealth { get; }

        void Heal(ushort amount, bool overrideMaxHealth = false);
        void Damage(ushort amount);
    }
}