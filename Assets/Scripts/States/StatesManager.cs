using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesManager : MonoBehaviour
{
    public static RunState TheRunState = new RunState();
    public static IdleState TheIdleState = new IdleState();

    private void Update()
    {
        
    }
}
