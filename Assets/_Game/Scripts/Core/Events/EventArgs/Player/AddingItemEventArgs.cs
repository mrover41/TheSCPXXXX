using Game.Core.Interfaces;
using Game.Core.Models;
using UnityEngine;

namespace Game.Core.Events.EventArgs.Player
{
    public class AddingItemEventArgs : IDeniableEvent
    {
        public AddingItemEventArgs(GameObject player, Item item)
        {
            Player = player;
            Item = item;
            IsAllowed = true;
        }
        
        public GameObject Player { get; set; }
        public Item Item { get; set; }
        public bool IsAllowed { get; set; }
    }
}