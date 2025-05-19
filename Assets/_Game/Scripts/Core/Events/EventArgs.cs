using System;
using UnityEngine;

namespace Game.Core.Events {
    public static class MyEventArgs {
        public class PlayerEventArgs {
            public class PlayerSpawnedEventArgs : EventArgs {
                public GameObject Player { get; }
                public bool isAllowed { get; set; } = true;
                public PlayerSpawnedEventArgs(GameObject player) {
                    Player = player;
                }
            }

            public class PlayerDiedEventArgs : EventArgs {
                public GameObject Player { get; }
                public bool isAllowed { get; set; } = true;

                public PlayerDiedEventArgs(GameObject player) {
                    Player = player;
                }
            }
        }

        public class SceneEventArgs {
            public class SceneLoadedEventArgs : EventArgs {
                public uint SceneID { get; }
                public bool isAllowed { get; set; } = true;

                public SceneLoadedEventArgs(uint sceneID) {
                    SceneID = sceneID;
                }
            }

            public class SceneUnloadedEventArgs : EventArgs {
                public uint SceneID { get; }
                public bool isAllowed { get; set; } = true;

                public SceneUnloadedEventArgs(uint sceneID) {
                    SceneID = sceneID;
                }
            }
        }
    }
}

