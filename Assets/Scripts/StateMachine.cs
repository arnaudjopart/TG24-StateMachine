using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        _chaseState = new ChasingState(_enemy, this);
        _idleState = new IdleState(_enemy, this);

        _currentState = _idleState;
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.Tick(Time.deltaTime);
    }

    public void GoToChaseState()
    {
        _currentState = _chaseState;
    }

    #region Private & Protected

    private IdleState _idleState;
    private ChasingState _chaseState;
    private State _currentState;

    [SerializeField] private ICanUseStateMachine _enemy;
    #endregion

}
