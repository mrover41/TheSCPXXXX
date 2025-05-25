using _Game.Core.Interfaces;
using UnityEngine;

namespace _Game.Core
{
    public class MovementModule : MonoBehaviour, IPlayerModule
    {
        [Header("Movement Settings")]
        [SerializeField] private float _walkSpeed = 5f;
        [SerializeField] private float _runSpeed = 10f;
        [SerializeField] private float _jumpHeight = 2f;
        [SerializeField] private float _gravity = -9.81f;

        private CharacterController _controller;
        private Vector3 _velocity;
        private float _currentSpeed;
        private bool _isGrounded;

        public void Initialize(PlayerEventSystem events)
        {
            _controller = GetComponent<CharacterController>();
            _currentSpeed = _walkSpeed;

            events.OnMove += HandleMovement;
            events.OnSprintStart += () => _currentSpeed = _runSpeed;
            events.OnSprintEnd += () => _currentSpeed = _walkSpeed;
        }

        public void UpdateModule(float deltaTime) 
        {
            HandleGravity();
            
            // Плавный сброс скорости (можно заменить на резкий)
            _velocity.x = Mathf.Lerp(_velocity.x, 0, deltaTime * 5);
            _velocity.z = Mathf.Lerp(_velocity.z, 0, deltaTime * 5);
            
            ApplyMovement();
        }

        private void HandleGravity()
        {
            _isGrounded = _controller.isGrounded;
            
            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f;
            }

            _velocity.y += _gravity * Time.deltaTime;
        }

        private void HandleMovement(Vector3 input) 
        {
            Vector3 moveDirection = transform.TransformDirection(input).normalized;
            moveDirection *= _currentSpeed;
            _velocity.x = moveDirection.x;
            _velocity.z = moveDirection.z;
        }

        private void ApplyMovement()
        {
            _controller.Move(_velocity * Time.deltaTime);
        }
    }
}