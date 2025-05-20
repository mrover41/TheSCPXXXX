using Game.Core.Events;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    [SerializeField] GameObject player;

    public Dictionary<Item, ushort> Items { get; private set; } = new();

    public void AddItem(Item item) {
        if (!EventBus.PlayerEvents.RaiseAddItem(new MyEventArgs.PlayerEventArgs.AddItemEventArgs(player, item)).isAllowed) return;
        if (Items.ContainsKey(item)) Items[item]++;
        else Items.Add(item, 1);
    }


    public void RemoveItem(Item item) {
        if (Items.ContainsKey(item)) {
            if (!EventBus.PlayerEvents.RaiseRemoveItem(new MyEventArgs.PlayerEventArgs.RemoveItemEventArgs(player, item)).isAllowed) return;
            Items[item]--;
            if (Items[item] == 0) Items.Remove(item);
        }
    }

    public void Clear() {
        if (EventBus.PlayerEvents.RaiseClearInventory(new MyEventArgs.PlayerEventArgs.ClearInventoryEventArgs(player)).isAllowed) return;
        Items.Clear();
    }
}
