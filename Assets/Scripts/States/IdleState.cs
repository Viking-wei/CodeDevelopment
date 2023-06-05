using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IBaseState
{
    public void DealInput()
    {
        Debug.Log("Idle State");
    }
}
