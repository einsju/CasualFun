using UnityEngine.UI;

namespace CasualFun
{
    public class SoundButton : AudioPlayer
    {
        Button _button;

        void Awake() => _button = GetComponent<Button>();

        void OnEnable() => _button.onClick.AddListener(PlaySound);
        void OnDisable() => _button.onClick.RemoveListener(PlaySound);
    }
}
