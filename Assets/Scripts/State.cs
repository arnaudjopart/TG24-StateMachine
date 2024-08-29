
using UnityEngine;

public abstract class State
{
    

    public State (ICanUseStateMachine character)
    {
        _character = character;
    }

    public abstract State Tick(float _deltaTime);
    public virtual void OnStateEnter()
    {

    }

    public virtual void OnStateExit()
    {

    }

    #region
    protected ICanUseStateMachine _character;
    #endregion
}

