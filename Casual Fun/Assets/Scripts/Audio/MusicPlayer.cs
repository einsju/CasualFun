using CasualFun.AtCirclesEdge.Storage;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicPlayer : MonoBehaviour
    {
        AudioSource _audioSource;
        bool _hasMusic;

        void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _hasMusic = Preferences.HasMusic;
        }

        void OnEnable() => AudioEventHandler.MusicOptionChanged += MusicOptionChanged;

        void OnDisable() => AudioEventHandler.MusicOptionChanged -= MusicOptionChanged;

        public void PlayMusic()
        {
            if (!_hasMusic) return;
            _audioSource.clip = MusicThemeCoordinator.GetMusicTheme();
            _audioSource.Play();
        }

        public void StopMusic() => _audioSource.Stop();

        void MusicOptionChanged(bool value) => _hasMusic = value;
    }
}
