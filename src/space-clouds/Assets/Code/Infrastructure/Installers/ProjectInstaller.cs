using Code.Common.Time;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Factory;
using Code.Infrastructure.Runner;
using Code.Infrastructure.States;
using Code.Logic.Curtain;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public LoadingCurtain CurtainPrefab;

        public override void InstallBindings()
        {
            BindInfrastructure();
            BindStateMachine();
            BindServices();
        }

        private void BindInfrastructure()
        {
            // ECS
            Contexts contexts = Contexts.sharedInstance;
            Container.Bind<Contexts>().FromInstance(contexts).AsSingle();
            Container.Bind<GameContext>().FromInstance(contexts.game).AsSingle();

            // Time
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();

            // Curtain — грузим через Resources
            Container.Bind<LoadingCurtain>()
                .FromComponentInNewPrefab(Resources.Load<LoadingCurtain>("Infastructure/Curtain"))
                .AsSingle()
                .NonLazy();

            Container.Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromNewComponentOnNewGameObject()
                .WithGameObjectName("CoroutineRunner")
                .AsSingle()
                .NonLazy();

            Container.Bind<SceneLoader>().AsSingle();
        }

        private void BindStateMachine()
        {
            // Каждое состояние — отдельный синглтон
            Container.Bind<BootstrapState>().AsSingle();
            Container.Bind<LoadLevelState>().AsSingle();
            Container.Bind<GameLoopState>().AsSingle();

            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<IAssets>().To<AssetProvider>().AsSingle();
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
        }
    }
}