using CasualFun.Handlers;
using CasualFun.Storage;
using UnityEngine;

namespace CasualFun
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] AudioClip button;
        [SerializeField] AudioClip screenTransition;
        [SerializeField] AudioClip itemCollected;
        [SerializeField] AudioClip gameOver;
        
        AudioSource _audioSource;
        bool _hasAudio;

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

        public void OnItemCollected()
        {
            if (!_hasAudio) return;
            _audioSource.PlayOneShot(itemCollected);
        }

        public void OnGameOver()
        {
            if (!_hasAudio) return;
            _audioSource.PlayOneShot(gameOver);
        }

        void SoundOptionChanged(bool value) => _hasAudio = value;
    }
}
