using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : State
{
    public ChasingState(ICanUseStateMachine enemy, StateMachine machine) : base(enemy, machine)
    {
    }

    public override void Tick(float _deltaTime)
    {
        Debug.Log("Chasing state");
    }

    
    
}
