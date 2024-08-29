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
        
        _character.MoveToTarget(_deltaTime);
        if (_character.HasLostTarget())
        {
            Debug.Log("HasLostTarget");
            _machine.GoToIdleState();
        }
        if (_character.HasReachedTarget())
        {

        }
    }

    public override void OnStateEnter()
    {
        _character.StartChase();
    }



}
