using CasualFun.Storage;
using UnityEngine;

namespace CasualFun.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] AudioClip button;
        [SerializeField] AudioClip screenTransition;
        [SerializeField] AudioClip itemCollected;
        [SerializeField] AudioClip enemySpawned;
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

        public void OnButtonClick() => PlayClip(button);
        
        public void OnScreenTransition() => PlayClip(screenTransition);

        public void OnItemCollected() => PlayClip(itemCollected);
        
        public void OnEnemySpawned() => PlayClip(enemySpawned);

        public void OnGameOver() => PlayClip(gameOver);

        void PlayClip(AudioClip clip)
        {
            if (!_hasAudio) return;
            _audioSource.PlayOneShot(clip);
        }

        void SoundOptionChanged(bool value) => _hasAudio = value;
    }
}
