using Zenject;

namespace Code.Infrastructure.States
{
    public class GameLoopState : IState
    {
        [Inject]
        public GameLoopState() { }
        
        public void Exit() { }
        public void Enter() { }
    }
}