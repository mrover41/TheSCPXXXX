using UnityEngine;

namespace Game.Core.Events.EventArgs.Player
{
    public class SpawnedEventArgs
    {
        public SpawnedEventArgs(GameObject player)
        {
            Player = player;
        }
        
        public GameObject Player { get; set; }
    }
}