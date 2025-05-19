using UnityEngine;

namespace Game.Player
{
    [DisallowMultipleComponent]
    public class PlayerCamera : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform cameraJoint;
        
        [Header("Settings")]
        [SerializeField] private bool invertCamera;
        [SerializeField] private float mouseSensitivity = 1f;
        [SerializeField] private float mouseMultiplier = 10f;
        [SerializeField] private float maxLookAngle = 90f;

        private float yaw;
        private float pitch;
        private Vector2 lookInput;

        private float currentFOV;
        private float fovVelocity;
        private float timer;
        
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                ToggleCursor();
            }

            HandleCameraMovement();
        }

        private void ToggleCursor()
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        private void HandleCameraMovement()
        {
            lookInput = new(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            
            Vector2 lookDelta = lookInput * (mouseSensitivity * Time.deltaTime * mouseMultiplier);

            yaw += lookDelta.x;
            pitch -= (invertCamera ? -1 : 1) * lookDelta.y;

            pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);

            transform.localEulerAngles = new Vector3(0, yaw, 0);
            cameraJoint.localEulerAngles = new Vector3(pitch, 0, 0);
        }
    }
}