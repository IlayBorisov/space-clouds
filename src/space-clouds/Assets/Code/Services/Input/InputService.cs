using Plugins.SimpleInput.Scripts;
using UnityEditor.Searcher;
using UnityEngine;

namespace Code.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";

        public abstract Vector2 Axis { get; }

        protected static Vector2 SimpleInputAxis() => 
            new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));

        protected static Vector2 UnityAxis() =>
            new(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
    }
}