using Code.Gameplay.Features.Input.Service;
using Code.Gameplay.Features.Input.Systems;

namespace Code.Gameplay.Features.Input
{
    public class InputFeature : Feature
    {
        public InputFeature(GameContext game, IInputService inputService)
        {
            Add(new InitializeInputSystem());
            Add(new EmitInputSystem(game, inputService));
        }
    }
}