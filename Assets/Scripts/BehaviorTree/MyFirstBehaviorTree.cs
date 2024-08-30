
using UnityEngine;

public class MyFirstBehaviorTree : MonoBehaviour
{
    #region Unity API
    private void Awake()
    {
        _mainNode = new SelectorNode();

        _compositeNode_01 = new SequenceNode();

        
        _compositeNode_01.children.Add(new TellMeSomethingLeaf("Bonjour les amis"));
        
        _compositeNode_01.children.Add(new WaitForSecondsLeaf(2));
        _compositeNode_01.children.Add(new ActivateGameObjectLeaf(_gameObject, true));
        _compositeNode_01.children.Add(new WaitForSecondsLeaf(2));
        _compositeNode_01.children.Add(new ActivateGameObjectLeaf(_gameObject, false));
        _compositeNode_01.children.Add(new TellMeSomethingLeaf("Ceci est une sequence"));


        _selectorNode = new SelectorNode();
        _selectorNode.children.Add(new TellMeSomethingLeaf("This is a Selector"));

        _mainNode.children.Add(_compositeNode_01);
        _mainNode.children.Add(_selectorNode);

    }

    private void Update()
    {
        _mainNode.Process();
    }

    private CompositeNode _mainNode;
    #endregion

    #region TagueuleTerence

    private CompositeNode _compositeNode_01;
    private SelectorNode _selectorNode;
    [SerializeField] private GameObject _gameObject;
    #endregion
}