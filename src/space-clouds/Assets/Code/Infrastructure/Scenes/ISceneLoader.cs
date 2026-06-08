using System;

namespace Code.Infrastructure.Scenes
{
    public interface ISceneLoader
    {
        void Load(string sceneName, Action onLoaded = null);
    }
}