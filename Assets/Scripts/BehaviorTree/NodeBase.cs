using System.Collections.Generic;
using UnityEngine;
public abstract class NodeBase
{
    public enum State
    {
        FAIL,
        SUCCESS,
        RUNNING
    }
    public abstract State Process();
}

public class Leaf : NodeBase
{
    public override State Process()
    {
        return State.SUCCESS;
    }
}

public class TellMeSomethingLeaf : Leaf
{
    private string _text;

    public TellMeSomethingLeaf(string text)
    {
        _text = text;
    }
    public override State Process()
    {
        Debug.Log(_text);
        return State.SUCCESS;
    }
}



public class CompositeNode : NodeBase
{
    public List<NodeBase> children;
    public override State Process()
    {
        return State.SUCCESS;
    }
}

public class SequenceNode : CompositeNode
{
    public override State Process()
    {
        return base.Process();
    }
}

public class SelectorNode : CompositeNode
{
    public override State Process()
    {
        return base.Process();
    }
}