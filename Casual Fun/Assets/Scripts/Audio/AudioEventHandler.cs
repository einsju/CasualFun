using System;

namespace CasualFun.Audio
{
    public abstract class AudioEventHandler
    {
        public static event Action<bool> SoundOptionChanged;
        public static event Action<bool> MusicOptionChanged;

        public static void OnSoundOptionChanged(bool value) => SoundOptionChanged?.Invoke(value);
        public static void OnMusicOptionChanged(bool value) => MusicOptionChanged?.Invoke(value);
    }
}
