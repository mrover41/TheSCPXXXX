using Game.Core.Interfaces;
using UnityEngine;

namespace Game.Core.Events.EventArgs.Player { 
    public class HealPlayerEventArg : IDeniableEvent {
        public HealPlayerEventArg(GameObject player, float health) { 
            Player = player;
            HealAmount = health;
            IsAllowed = true;
        }

        public GameObject Player { get; set; }
        public float HealAmount { get; set; }
        public bool IsAllowed { get; set; }
    }
}
