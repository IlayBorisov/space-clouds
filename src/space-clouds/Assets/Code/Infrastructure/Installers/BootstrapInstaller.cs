using Code.Common.Cameras;
using Code.Common.Collisions;
using Code.Common.Physics;
using Code.Common.Time;
using Code.Gameplay.Common.Identifiers.Service;
using Code.Gameplay.Features.Clouds.Service;
using Code.Gameplay.Features.Input.Service;
using Code.Gameplay.Features.Stars.Service;
using Code.Gameplay.Features.Wind;
using Code.Gameplay.Features.Wind.Service;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Factory;
using Code.Infrastructure.Runner;
using Code.Infrastructure.Services.Audio;
using Code.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindContexts();
            BindInfrastructure();
            BindStateMachine();
            BindServices();
        }

        private void BindContexts()
        {
            Contexts contexts = Contexts.sharedInstance;
            Container.Bind<Contexts>().FromInstance(contexts).AsSingle();
            Container.Bind<GameContext>().FromInstance(contexts.game).AsSingle();
        }

        private void BindInfrastructure()
        {
            Container.Bind<GameBootstrapper>()
                .FromComponentInHierarchy()
                .AsSingle();

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
            Container.Bind<BootstrapState>().AsSingle();
            Container.Bind<LoadLevelState>().AsSingle();
            Container.Bind<GameLoopState>().AsSingle();

            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
            
            Container.Bind<IAssets>().To<AssetProvider>().AsSingle();
            
            Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();

            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();

            Container.Bind<ICloudSpawnService>().To<CloudSpawnService>().AsSingle();
            Container.Bind<IStarSpawnService >().To<StarSpawnService>().AsSingle();

            Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
            
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
            Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
            
            Container.Bind<WindConfig>()
                .FromInstance(Resources.Load<WindConfig>("Configs/WindConfig"))
                .AsSingle();
            Container.Bind<IWindService>().To<WindService>().AsSingle();
            Container.Bind<IAudioService>().To<AudioService>().AsSingle();
        }
    }
}