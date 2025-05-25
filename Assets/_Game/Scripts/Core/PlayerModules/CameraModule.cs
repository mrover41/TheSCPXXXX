using _Game.Core.Interfaces;
using UnityEngine;

namespace _Game.Core
{
    public class CameraModule : MonoBehaviour, IPlayerModule
    {
        [Header("Settings")]
        [SerializeField] private float _sensitivity = 100f;
        [SerializeField] private Transform _cameraPivot;

        private float _xRotation;

        public void Initialize(PlayerEventSystem events)
        {
            Cursor.lockState = CursorLockMode.Locked;
            events.OnRotate += HandleRotation;
        }

        public void UpdateModule(float deltaTime) { }

        private void HandleRotation(Vector3 input)
        {
            float mouseX = input.x * _sensitivity * Time.deltaTime;
            float mouseY = input.y * _sensitivity * Time.deltaTime;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            _cameraPivot.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
    }
}