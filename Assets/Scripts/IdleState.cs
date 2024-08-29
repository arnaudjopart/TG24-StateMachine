
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : State
{

    

    public IdleState(ICanUseStateMachine character, StateMachine machine) : base(character, machine)
    {
    }

    public override void Tick(float _deltaTime)
    {
        _character.DoIdle(_deltaTime);

        if (_character.HasFoundTarget())
        {
            _machine.GoToChaseState();
        }
        
        
    }

    public override void OnStateEnter()
    {
        _character.StartIdle();
    }
}
  
