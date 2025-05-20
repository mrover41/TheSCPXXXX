using Game.Core.Interfaces;
using Game.Player;
using UnityEngine;

public class PlayerToggle : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private PlayerInventory playerInventory;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Physics.Raycast(head.position, head.forward, out RaycastHit hit);

            if (hit.transform.gameObject && !hit.transform.gameObject.CompareTag("Player") && hit.transform.gameObject.TryGetComponent(out IUsable usable))
            {
                usable.Use(playerInventory);
            }
        }
    }
}
