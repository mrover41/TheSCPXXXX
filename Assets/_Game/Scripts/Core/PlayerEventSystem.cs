using System;
using UnityEngine;

namespace _Game.Core
{
    public class PlayerEventSystem
    {
        public event Action<Vector3> OnMove;
        public event Action<Vector3> OnRotate;
        public event Action OnSprintStart;
        public event Action OnSprintEnd;

        public void TriggerMove(Vector3 direction) => OnMove?.Invoke(direction);
        public void TriggerRotate(Vector3 rotation) => OnRotate?.Invoke(rotation);
        public void TriggerSprintStart() => OnSprintStart?.Invoke();
        public void TriggerSprintEnd() => OnSprintEnd?.Invoke();
    }
}