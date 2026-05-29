namespace Code.Gameplay.Common.Entity
{
    public abstract class CreateEntity
    {
        public static GameEntity Empty() =>
            Contexts.sharedInstance.game.CreateEntity();
    }
}