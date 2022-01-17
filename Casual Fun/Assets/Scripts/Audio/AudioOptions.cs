using CasualFun.AtCirclesEdge.Storage;
using UnityEngine;
using UnityEngine.UI;

namespace CasualFun.AtCirclesEdge.Audio
{
    public class AudioOptions : MonoBehaviour
    {
        [SerializeField] Image soundButtonImage;
        [SerializeField] Image musicButtonImage;
        
        [SerializeField] Sprite soundOnSprite;
        [SerializeField] Sprite soundOffSprite;
        [SerializeField] Sprite musicOnSprite;
        [SerializeField] Sprite musicOffSprite;

        bool _hasAudio;
        bool _hasMusic;

        void Awake()
        {
            _hasAudio = Preferences.HasAudio;
            _hasMusic = Preferences.HasMusic;
            SetAudioButtonIcon();
            SetMusicButtonIcon();
        }
        
        void SetAudioButtonIcon() => soundButtonImage.sprite = _hasAudio ? soundOnSprite : soundOffSprite;
        void SetMusicButtonIcon() => musicButtonImage.sprite = _hasMusic ? musicOnSprite : musicOffSprite;

        public void OnToggleAudio()
        {
            _hasAudio = !_hasAudio;
            SetAudioButtonIcon();
            Preferences.SetAudio(_hasAudio);
            AudioEventHandler.OnSoundOptionChanged(_hasAudio);
        }

        public void OnToggleMusic()
        {
            _hasMusic = !_hasMusic;
            SetMusicButtonIcon();
            Preferences.SetMusic(_hasMusic);
            AudioEventHandler.OnMusicOptionChanged(_hasMusic);
        }
    }
}
