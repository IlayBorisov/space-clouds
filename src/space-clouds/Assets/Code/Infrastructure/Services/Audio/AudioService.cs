using UnityEngine;

namespace Code.Infrastructure.Services.Audio
{
    public class AudioService : IAudioService
    {
        private const string VolumeKey = "Volume";

        public float Volume
        {
            get => AudioListener.volume;
            set
            {
                AudioListener.volume = value;
                PlayerPrefs.SetFloat(VolumeKey, value);
                PlayerPrefs.Save();
            }
        }

        public AudioService()
        {
            AudioListener.volume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        }
    }
}
