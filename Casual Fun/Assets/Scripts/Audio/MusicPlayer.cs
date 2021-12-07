using CasualFun.AtCirclesEdge.State;
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

        void OnEnable()
        {
            AudioEventHandler.MusicOptionChanged += MusicOptionChanged;
            GameStateEventHandler.GameStarted += PlayMusic;
            GameStateEventHandler.GameOver += StopMusic;
        }

        void OnDisable()
        {
            AudioEventHandler.MusicOptionChanged -= MusicOptionChanged;
            GameStateEventHandler.GameStarted -= PlayMusic;
            GameStateEventHandler.GameOver -= StopMusic;
        }

        void PlayMusic()
        {
            if (!_hasMusic) return;
            _audioSource.clip = MusicThemeCoordinator.GetMusicTheme();
            _audioSource.Play();
        }

        void StopMusic() => _audioSource.Stop();

        void MusicOptionChanged(bool value) => _hasMusic = value;
    }
}
