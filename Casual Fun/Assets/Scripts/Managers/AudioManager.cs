using CasualFun.Handlers;
using CasualFun.Storage;
using UnityEngine;

namespace CasualFun.Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] AudioClip button;
        [SerializeField] AudioClip screenTransition;
        
        AudioSource _audioSource;
        bool _hasAudio;
        //bool _hasMusic;

        void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _hasAudio = Preferences.HasAudio;
        }

        void OnEnable() => AudioEventHandler.SoundOptionChanged += SoundOptionChanged;
        
        void OnDisable() => AudioEventHandler.SoundOptionChanged -= SoundOptionChanged;

        public void OnButtonClick()
        {
            if (!_hasAudio) return;
            _audioSource.PlayOneShot(button);
        }
        
        public void OnScreenTransition()
        {
            if (!_hasAudio) return;
            _audioSource.PlayOneShot(screenTransition);
        }

        void SoundOptionChanged(bool value) => _hasAudio = value;
    }
}
