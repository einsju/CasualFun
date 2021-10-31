using CasualFun.Handlers;
using CasualFun.Storage;
using UnityEngine;
using UnityEngine.UI;

namespace CasualFun
{
    public class Options : MonoBehaviour
    {
        [SerializeField] Image soundImage;
        [SerializeField] Image musicImage;
        
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
        
        void SetAudioButtonIcon() => soundImage.sprite = _hasAudio ? soundOnSprite : soundOffSprite;
        void SetMusicButtonIcon() => musicImage.sprite = _hasMusic ? musicOnSprite : musicOffSprite;

        public void OnToggleAudio()
        {
            _hasAudio = !_hasAudio;
            Preferences.SetAudio(_hasAudio);
            SetAudioButtonIcon();
            AudioEventHandler.OnSoundOptionChanged(_hasAudio);
        }

        public void OnToggleMusic()
        {
            _hasMusic = !_hasMusic;
            Preferences.SetMusic(_hasMusic);
            SetMusicButtonIcon();
            AudioEventHandler.OnMusicOptionChanged(_hasMusic);
        }

        public void OnRate() => Application.OpenURL("market://details?id=com.einarsen.casualfun");
        public void OnPrivacy() => Application.OpenURL("https://sjureinarsen.wixsite.com/casualfun/privacypolicy");
        public void OnQuit() => Application.Quit();
    }
}