using Code.Logic;
using UnityEngine;

namespace Code.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        private const string HeroPath = "Hero/hero";
        private const string HudPath = "Hud/Hud";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() => 
            _curtain.Hide();

        private void OnLoaded()
        {
            GameObject initialPoint = GameObject.FindWithTag(InitialPointTag);
            
            Instantiate(HeroPath, initialPoint.transform.position);
            Instantiate(HudPath);
            
            _stateMachine.Enter<GameLoopState>();
        }

        private static GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
        private static GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
    }
}