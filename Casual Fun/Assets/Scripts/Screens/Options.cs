using System.Collections.Generic;
using CasualFun.AtCirclesEdge.Audio;
using CasualFun.AtCirclesEdge.Storage;
using UnityEngine;
using UnityEngine.UI;

namespace CasualFun.AtCirclesEdge.Screens
{
    public class Options : MonoBehaviour
    {
        [SerializeField] List<Image> soundImages;
        [SerializeField] List<Image> musicImages;
        
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
        
        void SetAudioButtonIcon()
            => soundImages.ForEach(i => i.sprite = _hasAudio ? soundOnSprite : soundOffSprite);
        void SetMusicButtonIcon()
            => musicImages.ForEach(i => i.sprite = _hasMusic ? musicOnSprite : musicOffSprite);

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
