public interface ICanUseStateMachine
{
    void DoIdle(float deltaTime);
    string GetName();
    bool HasFoundTarget();
}