using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ObjectPool
{
    public class MyButton:MonoBehaviour
    {
        
        public UnityEvent destroyEvent = new UnityEvent();

        public bool isDestroy;
        public void OnEnable()
        {
            isDestroy = false;
        }
    }
}