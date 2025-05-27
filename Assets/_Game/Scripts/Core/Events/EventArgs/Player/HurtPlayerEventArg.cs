using Game.Core.Interfaces;
using UnityEngine;

namespace Game.Core.Events.EventArgs.Player {
    public class HurtPlayerEventArg {
        public HurtPlayerEventArg(GameObject player, float amount) {
            Player = player;
            HurtAmount = amount;
        }

        public GameObject Player { get; set; }
        public float HurtAmount { get; set; }
    }
}
