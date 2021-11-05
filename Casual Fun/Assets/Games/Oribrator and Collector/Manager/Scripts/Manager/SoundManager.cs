using UnityEngine;
using UnityEngine.UI;

namespace CasualFun.Games.OrbitratorAndCollector
{
    public class SoundManager : MonoBehaviour
    {
        Image _buttonImage;
        public Sprite[] buttonSprites;
        public AudioClip[] sounds;
        public static SoundManager Inst;

        void Awake()
        {
            Inst = this;
            var buttonObject = GameObject.FindGameObjectWithTag("soundButton");
            _buttonImage = buttonObject.GetComponent<Image>();
            var b = buttonObject.GetComponent<Button>();
            b.onClick.AddListener(ToggleAudio);
            SetToggle();
        }

        void SetToggle()
        {
            _buttonImage.sprite = AudioListener.volume == 1 ? buttonSprites[1] : buttonSprites[0];
        }

        public void ToggleAudio()
        {
            AudioListener.volume = AudioListener.volume == 1 ? 0 : 1;

            SetToggle();
        }

        public void PlaySound(int i)
        {
            AudioSource.PlayClipAtPoint(sounds[i], Vector3.zero);
        }
    }
}
