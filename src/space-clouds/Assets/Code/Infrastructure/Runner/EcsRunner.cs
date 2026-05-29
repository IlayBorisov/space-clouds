using Code.Common.Time;
using Code.Gameplay;
using Code.Gameplay.Input.Service;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Runner
{
    public class EcsRunner : MonoBehaviour
    {
        private GameContext _gameContext;
        private ITimeService _timeService;
        private IInputService _inputService;

        private BattleFeature _battleFeature;

        [Inject]
        private void Construct(GameContext gameContext, ITimeService timeService, IInputService inputService)
        {
            _timeService = timeService;
            _gameContext = gameContext;
            _inputService = inputService;
        }

        private void Start()
        {
            _battleFeature = new BattleFeature(_gameContext, _timeService, _inputService);
            _battleFeature.Initialize();
        }

        private void Update()
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }

        private void OnDestroy()
        {
            _battleFeature.TearDown();
        }
    }
}