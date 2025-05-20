using Game.Core.Models;
using UnityEngine;

namespace Game.Core.Events.EventArgs.Player
{
    public class RemovedItemEventArgs
    {
        public RemovedItemEventArgs(GameObject player, Item item)
        {
            Player = player;
            Item = item;
        }
        
        public GameObject Player { get; set; }
        public Item Item { get; set; }
    }
}