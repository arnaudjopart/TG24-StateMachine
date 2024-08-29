public interface ICanUseStateMachine
{
    void DoIdle(float deltaTime);
    string GetName();
    bool HasFoundTarget();
    bool HasLostTarget();
    bool HasReachedTarget();
    void MoveToTarget(float deltaTime);
    void StartChase();
    void StartIdle();
}