using Game.Core.Enums;
using Game.Core.Interfaces;
using Game.Player;
using UnityEngine;

namespace Game.Core.Models
{
    public class Pickup : MonoBehaviour, IUsable
    {
        public virtual ItemType Type { get; }
        
        public virtual void Use(PlayerInventory inv)
        {
            inv.AddItem(new(Type));
            Destroy(gameObject);
        }
    }
}