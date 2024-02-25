public class StateHandler
{
    public BehaviorBase CurrentState { get; private set; }

    public void Initialize(BehaviorBase state)
    {
        CurrentState = state;
        state.Enter();
    }

    public void ChangeState(BehaviorBase state)
    {
        if (CurrentState == state) return;

        CurrentState.Exit();

        CurrentState = state;
        state.Enter();
    }
}