using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Code.Infrastructure.Runner
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        [Inject]
        public SceneLoader(ICoroutineRunner coroutineRunner) => 
            _coroutineRunner = coroutineRunner;

        public void Load(string name, Action onLoader = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoader));

        private IEnumerator LoadScene(string nextScene, Action onLoader = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoader?.Invoke();
                yield break;
            }
            
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            while (!waitNextScene.isDone)
                yield return null;

            onLoader?.Invoke();
        }
    }
}