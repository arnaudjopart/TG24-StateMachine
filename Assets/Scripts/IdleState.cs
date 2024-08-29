
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : State
{
    public IdleState(ICanUseStateMachine character) : base(character)
    {
    }

    public override State Tick(float _deltaTime)
    {
        _character.DoIdle(_deltaTime);

        if (_character.HasFoundTarget())
        {
            return new ChasingState(_character);
        }
        return this;
        
    }

    public override void OnStateEnter()
    {
        _character.StartIdle();
    }
}
  
