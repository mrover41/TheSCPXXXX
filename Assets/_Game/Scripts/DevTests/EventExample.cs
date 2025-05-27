using Game.Core.Events.EventArgs.Player;
using UnityEngine;

public class EventExample : MonoBehaviour {
    [SerializeField] bool b = false;
    private void OnEnable() {
        Game.Core.Events.Handlers.Player.HurtingPlayer += OnHurting;
        Game.Core.Events.Handlers.Player.HurtPlayer += OnHurt;
    }

    private void OnDisable() {
        Game.Core.Events.Handlers.Player.HurtingPlayer -= OnHurting;
        Game.Core.Events.Handlers.Player.HurtPlayer -= OnHurt;
    }

    void OnHurting(HurtingPlayerEventArg ev) { 
        if (b) { 
            ev.IsAllowed = false;
        }
    }

    void OnHurt(HurtPlayerEventArg ev) {
        Debug.Log($"Hurt: {ev.HurtAmount}");
    }
}
