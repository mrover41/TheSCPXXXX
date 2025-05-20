using Game.Core.Enums;
using Game.Core.Models;
using Game.Player;
using UnityEngine;

namespace _Game.Scripts.Brick
{
    public class BrickPickup : Pickup
    {
        public override ItemType Type => ItemType.Brick;

        public override void Use(PlayerInventory inv)
        {
            Debug.Log("Brick pickuped");
            base.Use(inv);
        }
    }
}