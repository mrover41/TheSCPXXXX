using System;

namespace Game.Core.Events { 
    public static class EventBus {
        public static class PlayerEvents { 
            public static event Action<MyEventArgs.PlayerEventArgs.PlayerSpawnedEventArgs> PlayerSpawned;
            public static event Action<MyEventArgs.PlayerEventArgs.PlayerDiedEventArgs> PlayerDied;

            public static void RaisePlayerSpawned(MyEventArgs.PlayerEventArgs.PlayerSpawnedEventArgs arg) { 
                PlayerSpawned?.Invoke(arg);
            }

            public static void RaisePlayerDied(MyEventArgs.PlayerEventArgs.PlayerDiedEventArgs arg) { 
                PlayerDied?.Invoke(arg);
            }
        }

        public static class SceneEvents { 
            public static event Action<MyEventArgs.SceneEventArgs.SceneLoadedEventArgs> SceneLoaded;
            public static event Action<MyEventArgs.SceneEventArgs.SceneUnloadedEventArgs> SceneUnloaded;

            public static void RaiseSceneLoaded(MyEventArgs.SceneEventArgs.SceneLoadedEventArgs arg) {
                SceneLoaded?.Invoke(arg);
            }

            public static void RaiseSceneUnloaded(MyEventArgs.SceneEventArgs.SceneUnloadedEventArgs arg) {
                SceneUnloaded?.Invoke(arg);
            }
        }
    }
}

