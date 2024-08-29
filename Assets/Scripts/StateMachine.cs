using UnityEngine;

public class StateMachine : MonoBehaviour
{

    void Start()
    {
        _currentState = new IdleState(_enemy);
    }

    // Update is called once per frame
    void Update()
    {
        var possibleNextState = _currentState.Tick(Time.deltaTime);
        if (possibleNextState != _currentState)
        {
            _currentState.OnStateExit();
            _currentState = possibleNextState;
            _currentState.OnStateEnter();
        }
    }



    #region Private & Protected

    private State _currentState;

    [SerializeField] private Enemy _enemy;
    #endregion

}
