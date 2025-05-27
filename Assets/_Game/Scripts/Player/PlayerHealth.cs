using Game.Core.Interfaces;
using NaughtyAttributes;
using UnityEngine;
using Game.Core.Events.EventArgs.Player;

namespace Game.Player
{
    public class PlayerHealth : MonoBehaviour, IHealable
    {
        public ushort Health { get; private set; }
        public ushort MaxHealth { get; } = 100;

        private void Awake() {
            Health = MaxHealth;
        }
        
        public void Heal(ushort amount, bool overrideMaxHealth = false) {
            if (!Core.Events.Handlers.Player.OnHealPlayer(new(gameObject, amount)).IsAllowed) {
                return;
            }

            if (amount >= MaxHealth) {
                Health = MaxHealth;
            } else {
                Health += amount;
            }

            Core.Events.Handlers.Player.OnHealedPlayer(new(gameObject, Health));

            Debug.Log(Health);
        }

        public void Damage(ushort amount) {
            if (!Core.Events.Handlers.Player.OnHurtingPlayer(new(gameObject, amount)).IsAllowed) return;

            if (amount > Health) {
                Health = 0;
            } else {
                Health -= amount;
            }

            Core.Events.Handlers.Player.OnHurtPlayer(new(gameObject, amount));

            Debug.Log(Health);
        }

        [Button]
        private void Heal() => Heal(25);
        
        
        [Button]
        private void Damage() => Damage(25);
    }
}