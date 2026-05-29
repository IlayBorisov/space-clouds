using Code.Gameplay.Features.Input.Service;
using Entitas;

namespace Code.Gameplay.Features.Input.Systems
{
    public class EmitInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly SwipeInputService _swipeInputService;
        private readonly IGroup<GameEntity> _inputs;

        public EmitInputSystem(GameContext game, IInputService inputService)
        {
            _inputService = inputService;
            _swipeInputService = inputService as SwipeInputService;
            _inputs = game.GetGroup(GameMatcher.Input);
        }

        public void Execute()
        {
            _swipeInputService?.Update();
            foreach (GameEntity input in _inputs)
            {
                if (_inputService.HasAxis)
                    input.ReplaceAxisInput(_inputService.Axis);
                else if (input.hasAxisInput)
                    input.RemoveAxisInput();
            }
        }
    }
}