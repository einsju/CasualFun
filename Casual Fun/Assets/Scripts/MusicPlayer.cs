using CasualFun.Handlers;
using CasualFun.Storage;
using UnityEngine;

namespace CasualFun
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
            if (!_hasMusic) return;
            _audioSource.Play();
        }

        void StopOrResume(bool hasMusic)
        {
            _hasMusic = hasMusic;
            
            if (!_hasMusic)
            {
                _audioSource.Pause();
                return;
            }
            
            _audioSource.Play();
        }

        void OnEnable() => AudioEventHandler.MusicOptionChanged += MusicOptionChanged;
        
        void OnDisable() => AudioEventHandler.MusicOptionChanged -= MusicOptionChanged;

        void MusicOptionChanged(bool value) => StopOrResume(value);
    }
}
