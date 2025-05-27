using Game.Core.Interfaces;
using UnityEngine;

namespace Game.Core.Events.EventArgs.Player {
    public class HurtingPlayerEventArg : IDeniableEvent {
        public HurtingPlayerEventArg(GameObject player, float amount) {
            Player = player;
            HurtAmount = amount;
            IsAllowed = true;
        }

        public GameObject Player { get; set; }
        public float HurtAmount { get; set; }
        public bool IsAllowed { get; set; }
    }
}
