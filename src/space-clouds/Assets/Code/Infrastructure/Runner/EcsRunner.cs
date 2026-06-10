using Code.Gameplay;
using Code.Infrastructure.Systems;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Runner
{
    public class EcsRunner : MonoBehaviour
    {
        private GameContext _gameContext;
        private GameFeature _gameFeature;
        
        private ISystemsFactory _systemsFactory;

        [Inject]
        private void Construct(ISystemsFactory systemsFactory)
        {
            _systemsFactory = systemsFactory;
        }

        private void Start()
        {
            _gameFeature = new GameFeature(_systemsFactory);
            _gameFeature.Initialize();
        }

        private void Update()
        {
            _gameFeature?.Execute();
            _gameFeature?.Cleanup();
        }

        private void OnDestroy()
        {
            _gameFeature?.TearDown();
        }
    }
}