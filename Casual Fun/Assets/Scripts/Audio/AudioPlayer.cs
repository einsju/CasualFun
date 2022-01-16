using CasualFun.AtCirclesEdge.Storage;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class AudioPlayer : MonoBehaviour
    {   
        AudioSource _audioSource;
        bool _hasAudio;

        void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _hasAudio = Preferences.HasAudio;
            AudioEventHandler.SoundOptionChanged += SoundOptionChanged;
        }

        void OnDestroy() => AudioEventHandler.SoundOptionChanged -= SoundOptionChanged;
        
        protected void Play(AudioClip clip)
        {
            if (!_hasAudio) return;
            _audioSource.PlayOneShot(clip);
        }
        
        void SoundOptionChanged(bool value) => _hasAudio = value;
    }
}
