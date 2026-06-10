using Code.Common.Cameras;
using Code.Common.Collisions;
using Code.Common.Physics;
using Code.Common.Time;
using Code.Gameplay.Common.Identifiers.Service;
using Code.Gameplay.Features.Buffs.Tailwind.Config;
using Code.Gameplay.Features.Buffs.Tailwind.Factory;
using Code.Gameplay.Features.Buffs.Umbrella.Config;
using Code.Gameplay.Features.Buffs.Umbrella.Service;
using Code.Gameplay.Features.Clouds.Configs;
using Code.Gameplay.Features.Clouds.Service;
using Code.Gameplay.Features.Hearts.Service;
using Code.Gameplay.Features.Hero.Config;
using Code.Gameplay.Features.Input.Service;
using Code.Gameplay.Features.Stars.Configs;
using Code.Gameplay.Features.Stars.Factory;
using Code.Gameplay.Features.Wind;
using Code.Gameplay.Features.Wind.Configs;
using Code.Gameplay.Features.Wind.Service;
using Code.Gameplay.GameCycle.Services;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Factory;
using Code.Infrastructure.Runner;
using Code.Infrastructure.Scenes;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.UI.Audio;
using Code.Infrastructure.UI.Hud;
using Code.Infrastructure.UI.Hud.Services;
using Code.Infrastructure.UI.Menu;
using Code.Infrastructure.UI.Menu.Services;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInstallers();
            BindStateMachine();
            BindContexts();
            BindFactories();
            BindLoaders();
            BindInfrastructure();
            BindConfigs();
            BindServices();
        }
        
        private void BindInstallers()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }

        private void BindStateMachine()
        {
            Container.Bind<BootstrapState>().AsSingle();
            Container.Bind<LoadLevelState>().AsSingle();
            Container.Bind<GameLoopState>().AsSingle();
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
        }

        private void BindContexts()
        {
            Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game);
        }

        private void BindFactories()
        {
            //Container.Bind<ISystemsFactory>().To<SystemsFactory>().AsSingle();
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.Bind<IStarFactory>().To<StarFactory>().AsSingle();
            Container.Bind<ITailwindFactory>().To<TailwindFactory>().AsSingle();
        }
        
        private void BindLoaders()
        {
            Container.Bind<SceneLoader>().AsSingle();
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
        }

        private void BindConfigs()
        {
            Container.Bind<WindConfig>()
                .FromInstance(Resources.Load<WindConfig>("Configs/WindConfig"))
                .AsSingle();
            Container.Bind<UmbrellaConfig>()
                .FromScriptableObjectResource("Configs/UmbrellaConfig")
                .AsSingle();
            Container.Bind<TailwindConfig>()
                .FromScriptableObjectResource("Configs/TailwindConfig")
                .AsSingle();
            Container.Bind<HeroConfig>()
                .FromScriptableObjectResource("Configs/Hero/HeroConfig")
                .AsSingle();
            Container.Bind<CloudConfig>()
                .FromScriptableObjectResource("Configs/Cloud/CloudConfig")
                .AsSingle();
            Container.Bind<StarConfig>()
                .FromScriptableObjectResource("Configs/Star/StarConfig")
                .AsSingle();
        }
        
        private void BindServices()
        {
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
            Container.Bind<IAssets>().To<AssetProvider>().AsSingle();
            Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
            Container.Bind<ICloudSpawnService>().To<CloudSpawnService>().AsSingle();
            Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
            Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
            Container.Bind<IWindService>().To<WindService>().AsSingle();
            Container.Bind<IAudioService>().To<AudioService>().AsSingle();
            Container.Bind<IHeartsService>().To<HeartsService>().AsSingle();
            Container.Bind<IUmbrellaSpawnService>().To<UmbrellaSpawnService>().AsSingle();
            Container.Bind<IInitialPointService>().To<InitialPointService>().AsSingle();
        }
    }
}