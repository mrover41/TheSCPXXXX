using UnityEngine;

namespace Game.Player
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CharacterController _controller;
        [SerializeField] private Transform _cameraTransform;
        
        [Header("Movement Settings")]
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _acceleration = 10f;
        [SerializeField] private float _airControlMultiplier = 0.5f;
        
        [Header("Gravity")]
        [SerializeField] private float _gravityMultiplier = 2f;
        [SerializeField] private float _groundedCheckDistance = 0.1f;
        [SerializeField] private LayerMask _groundLayers;

        private Vector3 _currentVelocity;
        private Vector3 _moveInput;
        private bool _isGrounded;
        private float _verticalVelocity;
        private const float GRAVITY = -9.81f;

        private void Awake()
        {
            ValidateReferences();
            InitializeComponents();
        }

        private void Start()
        {
            Core.Events.Handlers.Player.OnSpawned(new(gameObject));
        }

        private void Update()
        {
            GatherInput();
            HandleGroundCheck();
            HandleMovement();
            ApplyGravity();
            FinalizeMovement();
        }

        private void ValidateReferences()
        {
            if (_controller == null)
                _controller = GetComponent<CharacterController>();
            
            if (_cameraTransform == null)
                _cameraTransform = Camera.main!.transform;
        }

        private void InitializeComponents()
        {
            _controller.minMoveDistance = 0f;
        }

        private void GatherInput()
        {
            _moveInput = new Vector3(
                Input.GetAxisRaw("Horizontal"),
                0f,
                Input.GetAxisRaw("Vertical")
            ).normalized;
        }

        private void HandleGroundCheck()
        {
            _isGrounded = _controller.isGrounded || 
                         Physics.CheckSphere(transform.position, _groundedCheckDistance, _groundLayers);
        }

        private void HandleMovement()
        {
            Vector3 cameraForward = Vector3.Scale(_cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 targetDirection = _moveInput.z * cameraForward + _moveInput.x * _cameraTransform.right;

            float controlMultiplier = _isGrounded ? 1f : _airControlMultiplier;
            Vector3 targetVelocity = targetDirection * (_moveSpeed * controlMultiplier);

            _currentVelocity = Vector3.Lerp(
                _currentVelocity, 
                targetVelocity, 
                _acceleration * Time.deltaTime
            );
        }

        private void ApplyGravity()
        {
            if (_isGrounded && _verticalVelocity < 0)
            {
                _verticalVelocity = -0.5f;
            }
            else
            {
                _verticalVelocity += GRAVITY * _gravityMultiplier * Time.deltaTime;
            }
        }

        private void FinalizeMovement()
        {
            Vector3 verticalMovement = Vector3.up * _verticalVelocity;
            Vector3 combinedMovement = _currentVelocity + verticalMovement;
            
            _controller.Move(combinedMovement * Time.deltaTime);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _groundedCheckDistance);
        }
    }
}