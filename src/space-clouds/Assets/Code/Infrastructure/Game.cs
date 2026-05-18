using System.Net.Mime;
using Code.Logic;
using Code.Services.Input;
using UnityEngine;

namespace Code.Infrastructure
{
    public class Game
    {
        public static IInputService InputService;
        public GameStateMachine StateMachine;
        
        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain);
            RegisterInput();
        }
        
        private static void RegisterInput()
        {
            if (Application.isEditor)
                InputService = new StandaloneInputService();
            else
                InputService = new MobileInputService();
        }
    }
}