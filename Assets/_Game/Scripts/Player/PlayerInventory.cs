using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Game.Core.Models;
using UnityEngine;

namespace Game.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializedDictionary] public Dictionary<Item, ushort> Items { get; private set; } = new();

        public void AddItem(Item item)
        {
            if (!Core.Events.Handlers.Player.OnAddingItem(new(gameObject, item)).IsAllowed) return;
            
            if (!Items.TryAdd(item, 1))
            {
                Items[item]++;
            }
            Core.Events.Handlers.Player.OnAddedItem(new(gameObject, item));
        }
    
        public void RemoveItem(Item item)
        {
            if (Items.ContainsKey(item))
            {
                if (!Core.Events.Handlers.Player.OnRemovingItem(new(gameObject, item)).IsAllowed) return;
                
                Items[item]--;
                if (Items[item] == 0)
                {
                    Items.Remove(item);
                }
                Core.Events.Handlers.Player.OnRemovedItem(new(gameObject, item));
            }
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}