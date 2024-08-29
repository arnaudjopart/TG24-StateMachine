using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : State
{
    public ChasingState(ICanUseStateMachine enemy) : base(enemy)
    {
    }

    public override State Tick(float _deltaTime)
    {
        
        _character.MoveToTarget(_deltaTime);
        if (_character.HasLostTarget())
        {
            Debug.Log("HasLostTarget");
            return new IdleState(_character);
        }
        if (_character.HasReachedTarget())
        {

        }
        return this;
    }

    public override void OnStateEnter()
    {
        _character.StartChase();
    }



}
