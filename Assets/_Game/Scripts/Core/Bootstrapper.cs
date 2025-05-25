using System.Collections.Generic;
using System.Linq;
using _Game.Core.Interfaces;
using UnityEngine;

namespace _Game.Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [Tooltip("Drag initialization order here")]
        [SerializeField] private List<MonoBehaviour> _initializationSequence;

        private void Awake()
        {
            InitializeSystems();
        }

        private void InitializeSystems()
        {
            foreach (var system in _initializationSequence.OfType<IInitializable>())
            {
                system.Initialize();
            }
        }
    }
}