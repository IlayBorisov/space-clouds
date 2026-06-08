using Entitas;

namespace Code.Infrastructure.Systems
{
    public interface ISystemsFactory
    {
        TSystem Create<TSystem>() where TSystem : ISystem;
        TSystem Create<TSystem>(params object[] args) where TSystem : ISystem;
    }
}