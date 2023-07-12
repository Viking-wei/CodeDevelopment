using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Gravity
{
    [RequireComponent(typeof(Rigidbody))]
    public class GravityComponent : MonoBehaviour
    {
        public float GravityFactorFactor = 1f;
        public float VelocityLimit = 6f;
        private Rigidbody _rigidbody;
        [Header("Debug")] 
        public bool IsGravityEnable=false;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if(IsGravityEnable)
                UpdateVelocity();
        }
        private void UpdateVelocity()
        {
            var temp = _rigidbody.velocity;
            temp += GlobalGravity.Instance.Gravity * (GravityFactorFactor * Time.fixedDeltaTime);
            temp = temp.normalized *
                   Mathf.Min(temp.magnitude, VelocityLimit);
            _rigidbody.velocity = temp;
        }
    }
}

