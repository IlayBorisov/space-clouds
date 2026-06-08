namespace Code.Infrastructure.States.Factory
{
    public interface IStateFactory
    {
        TState GetState<TState>() where TState : IState;
    }
}