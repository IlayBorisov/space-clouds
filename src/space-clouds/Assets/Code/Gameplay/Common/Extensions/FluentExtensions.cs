using System;

namespace Code.Gameplay.Common.Extensions
{
    public static class FluentExtensions
    {
        public static T With<T>(this T self, Action<T> apply)
        {
            apply?.Invoke(self);
            return self;
        }
    }
}