using System;
using UnityEngine;
using UnityEngine.UI;

namespace CasualFun.Games.OrbitratorAndCollector
{
    public class SoundManager : MonoBehaviour
    {
        public Sprite[] buttonSprites;
        public AudioClip[] sounds;
        public static SoundManager Inst;
        
        Image _buttonImage;

        void Awake()
        {
            Inst = this;
            var buttonObject = GameObject.FindGameObjectWithTag("soundButton");
            //_buttonImage = buttonObject.GetComponent<Image>();
            //var b = buttonObject.GetComponent<Button>();
            //b.onClick.AddListener(ToggleAudio);
            //SetToggle();
        }

        public void ToggleAudio()
        {
            AudioListener.volume = Math.Abs(AudioListener.volume - 1f) <= 0.01f ? 0 : 1;
            SetToggle();
        }

        void SetToggle() => _buttonImage.sprite = Math.Abs(AudioListener.volume - 1f) < 0.01f ? buttonSprites[1] : buttonSprites[0];

        public void PlaySound(int i) => AudioSource.PlayClipAtPoint(sounds[i], Vector3.zero);
    }
}
