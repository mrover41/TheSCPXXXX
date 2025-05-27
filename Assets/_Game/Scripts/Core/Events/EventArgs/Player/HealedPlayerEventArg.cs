using UnityEngine;

namespace Game.Core.Events.EventArgs.Player { 
    public class HealedPlayerEventArg {
        public HealedPlayerEventArg(GameObject player, float health) {
            Player = player;
            HealAmount = health;
        }

        public GameObject Player { get; set; }
        public float HealAmount { get; set; }
    }
}
