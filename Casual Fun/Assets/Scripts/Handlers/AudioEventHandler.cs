using System;
using UnityEngine;

namespace CasualFun.Handlers
{
    public abstract class AudioEventHandler
    {
        public static event Action<AudioClip> PlaySound;
        public static event Action<bool> SoundOptionChanged;
        public static event Action<bool> MusicOptionChanged;

        public static void OnPlaySound(AudioClip clip) => PlaySound?.Invoke(clip);
        public static void OnSoundOptionChanged(bool value) => SoundOptionChanged?.Invoke(value);
        public static void OnMusicOptionChanged(bool value) => MusicOptionChanged?.Invoke(value);
    }
}
