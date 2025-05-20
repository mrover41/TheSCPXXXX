using Game.Core.Enums;
using Game.Core.Interfaces;
using Game.Player;

namespace Game.Core.Models
{
    public class Item : IUsable
    {
        public Item(ItemType itemType)
        {
            Type = itemType;
        }
        
        public virtual ItemType Type { get; private set; }

        public virtual void Use(PlayerInventory inv) { }
    }
}
