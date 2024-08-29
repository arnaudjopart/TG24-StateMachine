using System;
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
        return _target.gameObject.activeSelf && IsTargetInRange(_target, _detectionRange);
    }

    public bool HasLostTarget()
    {
        return !IsTargetInRange(_target, _outOfRangeDistance);
    }

    public bool HasReachedTarget()
    {
        return IsTargetInRange(_target, 0.01f);
    }

    private bool IsTargetInRange(Transform target, float v)
    {
        return Vector3.SqrMagnitude(target.position - transform.position) <= v * v;

    }

    public void MoveToTarget(float deltaTime)
    {
        var direction = (_target.position - transform.position).normalized;
        transform.position += direction * deltaTime * _moveSpeed;
    }

    public void StartChase()
    {
        GetComponent<MeshRenderer>().material = _chaseMaterial;
    }

    public void StartIdle()
    {
        GetComponent<MeshRenderer>().material = _idleMaterial;
    }

    #region Private & Protected

    [SerializeField] private float _detectionRange = 5;
    [SerializeField] private float _moveSpeed = 2;
    [SerializeField] private float _health = 100;
    [SerializeField] private float _stamina = 0;
    [SerializeField] private Transform _target;
    [SerializeField] private float _outOfRangeDistance =7;
    [SerializeField] private Material _chaseMaterial;
    [SerializeField] private Material _idleMaterial;


    #endregion
}