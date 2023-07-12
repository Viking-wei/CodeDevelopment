using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gravity
{
    public class PlayerController : MonoBehaviour
    {
        public void ChangeGravity(InputAction.CallbackContext context)
        {
            if (!context.started) return;
            
            var gravityDirection = context.ReadValue<Vector2>();
            GlobalGravity.Instance.ChangeDirection(gravityDirection);
        }
    }
}

