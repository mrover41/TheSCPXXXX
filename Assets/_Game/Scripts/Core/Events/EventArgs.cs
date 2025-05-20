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

            public class AddItemEventArgs : EventArgs {
                public GameObject Player { get; }
                public Item Item { get; }
                public bool isAllowed { get; set; } = true;

                public AddItemEventArgs(GameObject player, Item item) {
                    Player = player;
                    Item = item;
                }
            }

            public class RemoveItemEventArgs : EventArgs {
                public GameObject player { get; }
                public Item Item { get; }
                public bool isAllowed { get; set; } = true;
                public RemoveItemEventArgs(GameObject player, Item item) {
                    this.player = player;
                    this.Item = item;
                }
            }

            public class ClearInventoryEventArgs : EventArgs {
                public GameObject player { get; }
                public bool isAllowed { get; set; } = true;
                public ClearInventoryEventArgs(GameObject player) {
                    this.player = player;
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

        public class GameEventArgs {
            public class GameStartedEventArgs : EventArgs {

            }

            public class GameEndedEventArgs : EventArgs {

            }

            public class  ChangeSettingEventArgs : EventArgs {
                public bool isAllowed { get; set; }
                public string SettingName { get; }
                public float Value { get; }

                public ChangeSettingEventArgs(string settingName, float value) {
                    SettingName = settingName;
                    Value = value;
                }
            }

            public class ChangeDangerLevelEventArgs : EventArgs {
                public bool isAllowed { get; set; }
                public uint DangerLevel { get; }

                public ChangeDangerLevelEventArgs(uint dangerLevel) {
                    DangerLevel = dangerLevel;
                }
            }
        }
    }
}

