using UnityEngine;

public class ActivateGameObjectLeaf : Leaf
{
    private GameObject _gameObject;
    private bool _enabled;

    public ActivateGameObjectLeaf(GameObject gameObject, bool v)
    {
        _gameObject = gameObject;
        _enabled = v;
    }

    public override State Process()
    {
        if (_gameObject == null) return State.FAIL;
        _gameObject.SetActive(_enabled);
        return State.SUCCESS;
    }
}