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
        _currentState.OnStateExit();
        _currentState = _chaseState;
        _currentState.OnStateEnter();
    }

    public void GoToIdleState()
    {
        _currentState.OnStateExit();
        _currentState = _idleState;
        _currentState.OnStateEnter();

        
    }

    #region Private & Protected

    private IdleState _idleState;
    private ChasingState _chaseState;
    private State _currentState;

    [SerializeField] private Enemy _enemy;
    #endregion

}
