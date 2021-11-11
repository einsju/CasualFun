using CasualFun.Handlers;
using CasualFun.Storage;
using UnityEngine;

namespace CasualFun
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] int numberOfMusicThemes = 14;
        
        AudioSource _audioSource;
        bool _hasMusic;

        void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = PickRandomTheme();
            
            _hasMusic = Preferences.HasMusic;
            if (!_hasMusic) return;
            _audioSource.Play();
        }
        
        int RandomTheme => Random.Range(1, numberOfMusicThemes + 1);
        AudioClip PickRandomTheme() => Resources.Load($"Music/Theme_{RandomTheme}") as AudioClip;

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
