using Game.Core.Interfaces;
using NaughtyAttributes;
using UnityEngine;

namespace Game.Player
{
    public class PlayerHealth : MonoBehaviour, IHealable
    {
        public ushort Health { get; private set; }
        public ushort MaxHealth { get; } = 100;

        private void Awake()
        {
            Health = MaxHealth;
        }
        
        public void Heal(ushort amount, bool overrideMaxHealth = false)
        {
            if (amount >= MaxHealth)
            {
                Health = MaxHealth;
            }
            else
            {
                Health += amount;
            }
            
            Debug.Log(Health);
        }

        public void Damage(ushort amount)
        {
            if (amount > Health)
            {
                Health = 0;
            }
            else
            {
                Health -= amount;
            }
            
            Debug.Log(Health);
        }

        [Button]
        private void Heal() => Heal(25);
        
        
        [Button]
        private void Damage() => Damage(25);
    }
}