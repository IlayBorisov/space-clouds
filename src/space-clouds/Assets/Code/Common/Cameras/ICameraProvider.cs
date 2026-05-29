using UnityEngine;

namespace Code.Common.Cameras
{
    public interface ICameraProvider
    {
        Camera MainCamera { get; }
        float WorldScreenHeight { get; }
        float WorldScreenWidth { get; }
        float WorldScreenBottom { get; }
        void SetMainCamera(Camera camera);
    }
}