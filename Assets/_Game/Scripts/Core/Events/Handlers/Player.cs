using System;
using Game.Core.Events.EventArgs.Player;

namespace Game.Core.Events.Handlers
{
    public static class Player
    {
        public static event Action<AddedItemEventArgs> AddedItem;
        public static event Action<AddingItemEventArgs> AddingItem;
        public static event Action<RemovedItemEventArgs> RemovedItem;
        public static event Action<RemovingItemEventArgs> RemovingItem;
        public static event Action<SpawnedEventArgs> Spawned;

        internal static AddedItemEventArgs OnAddedItem(AddedItemEventArgs ev)
        {
            AddedItem?.Invoke(ev);
            return ev;
        }

        internal static AddingItemEventArgs OnAddingItem(AddingItemEventArgs ev)
        {
            AddingItem?.Invoke(ev);
            return ev;
        }

        internal static RemovedItemEventArgs OnRemovedItem(RemovedItemEventArgs ev)
        {
            RemovedItem?.Invoke(ev);
            return ev;
        }

        internal static RemovingItemEventArgs OnRemovingItem(RemovingItemEventArgs ev)
        {
            RemovingItem?.Invoke(ev);
            return ev;
        }

        internal static SpawnedEventArgs OnSpawned(SpawnedEventArgs ev)
        {
            Spawned?.Invoke(ev);
            return ev;
        }
    }
}