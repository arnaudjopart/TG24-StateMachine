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



public abstract class CompositeNode : NodeBase
{
    public List<NodeBase> children = new List<NodeBase>();
    protected int m_index;
    public override abstract State Process();
}

public class SequenceNode : CompositeNode
{
    public override State Process()
    {
        var childState = children[m_index].Process();
        if (childState == State.SUCCESS) 
        {
            m_index++;
            if(m_index >= children.Count)
            {
                m_index = 0;
                return State.SUCCESS;
            }
            return State.RUNNING;
        }
        if(childState == State.FAIL) 
        {
            m_index = 0;
            return State.FAIL;
        }

        return State.RUNNING;
    }
}

public class SelectorNode : CompositeNode
{
    public override State Process()
    {
        var childState = children[m_index].Process();
        if (childState == State.SUCCESS)
        {
            m_index = 0;
            return State.SUCCESS;
        }
        if(childState == State.FAIL)
        {
            m_index++;
            if(m_index >= children.Count)
            {
                m_index = 0;
                return State.FAIL;
            }
        }
        return State.RUNNING;

    }
}

public class WaitForSecondsLeaf : Leaf
{
    public WaitForSecondsLeaf(float duration)
    {
        _duration = duration;

    }
    public override State Process()
    {
        _timer += Time.deltaTime;
        if(_timer >= _duration)
        {
            _timer = 0;
            return State.SUCCESS;
        }
        return State.RUNNING;
    }

    private float _timer;
    private float _duration;
}

public class ReturnFailLeaf : Leaf
{
    public override State Process()
    {
        return State.FAIL;
    }
}