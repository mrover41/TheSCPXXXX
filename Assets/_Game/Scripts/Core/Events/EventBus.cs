using System;

namespace Game.Core.Events { 
    using static MyEventArgs;
    public static class EventBus {
        public static class PlayerEvents { 
            public static event Action<PlayerEventArgs.PlayerSpawnedEventArgs> PlayerSpawned;
            public static event Action<PlayerEventArgs.PlayerDiedEventArgs> PlayerDied;
        }

        public static class SceneEvents { 
            public static event Action<SceneEventArgs.SceneLoadedEventArgs> SceneLoaded;
            public static event Action<SceneEventArgs.SceneUnloadedEventArgs> SceneUnloaded;
        }
    }
}

