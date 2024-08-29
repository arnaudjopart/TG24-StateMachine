
using UnityEngine;

public abstract class State
{
    

    public State (ICanUseStateMachine character, StateMachine machine)
    {
        _character = character;
        _machine = machine;
    }

    public abstract void Tick(float _deltaTime);
    public virtual void OnStateEnter()
    {

    }

    public virtual void OnStateExit()
    {

    }

    #region
    protected ICanUseStateMachine _character;
    protected StateMachine _machine;
    #endregion
}

