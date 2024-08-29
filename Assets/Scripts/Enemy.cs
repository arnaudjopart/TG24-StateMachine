using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour, ICanUseStateMachine
{

    public void DoIdle(float deltaTime)
    {
        
      
    }

    public string GetName()
    {
        return gameObject.name;
    }

    public bool HasFoundTarget()
{
        return Vector3.SqrMagnitude(_target.position - transform.position) <= _detectionRange * _detectionRange;
    
    }

    #region Private & Protected

    [SerializeField] private float _detectionRange = 5;
    [SerializeField] private float _moveSpeed = 2;
    [SerializeField] private float _health = 100;
    [SerializeField] private float _stamina = 0;
    [SerializeField] private Transform _target;

    
    #endregion
}