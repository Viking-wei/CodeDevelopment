using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gravity
{
    [RequireComponent(typeof(BoxCollider))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Debug")] 
        public Color AreaColor =Color.cyan;

        public BoxCollider TheBoxCollider;
        
        public void ChangeGravity(InputAction.CallbackContext context)
        {
            if (!context.started) return;
            
            var gravityDirection = context.ReadValue<Vector2>();
            GlobalGravity.Instance.ChangeDirection(gravityDirection);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Dynamic")) return;

            other.GetComponent<GravityComponent>().IsGravityEnable = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Dynamic")) return;

            other.GetComponent<GravityComponent>().IsGravityEnable = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = AreaColor;
            Gizmos.DrawCube(transform.position, TheBoxCollider.size);
        }
    }
}

