using System.Collections.Generic;
using System.Linq;
using _Game.Core.Interfaces;
using UnityEngine;

namespace _Game.Core
{
    public class Player : MonoBehaviour, IInitializable
    {
        public static Player Instance { get; private set; }

        [Header("Modules")]
        [SerializeField] private List<MonoBehaviour> _playerModules;

        private PlayerEventSystem _eventSystem = new();
        private List<IPlayerModule> _modules = new();

        public void Initialize()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;

            InitializeModules();
        }

        private void InitializeModules()
        {
            _modules = _playerModules
                .OfType<IPlayerModule>()
                .ToList();

            foreach (var module in _modules)
            {
                module.Initialize(_eventSystem);
            }
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            HandleInput();
            
            foreach (var module in _modules)
            {
                module.UpdateModule(deltaTime);
            }
        }

        private void HandleInput()
        {
            // Обработка ввода и триггер событий
            Vector3 moveInput = new Vector3(
                Input.GetAxis("Horizontal"),
                0,
                Input.GetAxis("Vertical")
            );
            
            Vector3 lookInput = new Vector3(
                Input.GetAxis("Mouse X"),
                Input.GetAxis("Mouse Y"),
                0
            );

            if (moveInput != Vector3.zero)
                _eventSystem.TriggerMove(moveInput);

            if (lookInput != Vector3.zero)
                _eventSystem.TriggerRotate(lookInput);

            if (Input.GetKeyDown(KeyCode.LeftShift))
                _eventSystem.TriggerSprintStart();

            if (Input.GetKeyUp(KeyCode.LeftShift))
                _eventSystem.TriggerSprintEnd();
        }
    }
}