using System;
using static Game.Core.Events.MyEventArgs.PlayerEventArgs;
using static Game.Core.Events.MyEventArgs.SceneEventArgs;
using static Game.Core.Events.MyEventArgs.GameEventArgs;

namespace Game.Core.Events { 
    public static class EventBus {
        public static class PlayerEvents {
            public static event Action<PlayerSpawnedEventArgs> PlayerSpawned;
            public static event Action<PlayerDiedEventArgs> PlayerDied;
            public static event Action<AddItemEventArgs> AddItem;
            public static event Action<RemoveItemEventArgs> RemoveItem;
            public static event Action<ClearInventoryEventArgs> ClearInventory;

            internal static PlayerSpawnedEventArgs RaisePlayerSpawned(PlayerSpawnedEventArgs arg) { 
                PlayerSpawned?.Invoke(arg);
                return arg;
            }

            internal static PlayerDiedEventArgs RaisePlayerDied(PlayerDiedEventArgs arg) { 
                PlayerDied?.Invoke(arg);
                return arg;
            }
            internal static AddItemEventArgs RaiseAddItem(AddItemEventArgs arg) {
                AddItem?.Invoke(arg);
                return arg;
            }
            internal static RemoveItemEventArgs RaiseRemoveItem(RemoveItemEventArgs arg) {
                RemoveItem?.Invoke(arg);
                return arg;
            }
            internal static ClearInventoryEventArgs RaiseClearInventory(ClearInventoryEventArgs arg) {
                ClearInventory?.Invoke(arg);
                return arg;
            }
        }

        public static class SceneEvents { 
            public static event Action<SceneLoadedEventArgs> SceneLoaded;
            public static event Action<SceneUnloadedEventArgs> SceneUnloaded;

            internal static SceneLoadedEventArgs RaiseSceneLoaded(SceneLoadedEventArgs arg) {
                SceneLoaded?.Invoke(arg);
                return arg;
            }

            internal static SceneUnloadedEventArgs RaiseSceneUnloaded(SceneUnloadedEventArgs arg) {
                SceneUnloaded?.Invoke(arg);
                return arg;
            }
        }

        public static class GameEvents {
            public static event Action<GameStartedEventArgs> GameStarted;
            public static event Action<GameEndedEventArgs> GameEnded;
            public static event Action<ChangeSettingEventArgs> ChangeSetting;

            internal static GameStartedEventArgs RaiseGameStarted(GameStartedEventArgs arg) {
                GameStarted?.Invoke(arg);
                return arg;
            }

            internal static GameEndedEventArgs RaiseGameEnded(GameEndedEventArgs arg) {
                GameEnded?.Invoke(arg);
                return arg;
            }

            internal static ChangeSettingEventArgs RaiseChangeSetting(ChangeSettingEventArgs arg) {
                ChangeSetting?.Invoke(arg);
                return arg;
            }
        }
    }
}

