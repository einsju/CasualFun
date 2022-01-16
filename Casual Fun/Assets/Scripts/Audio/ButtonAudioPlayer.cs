using UnityEngine;

namespace CasualFun.AtCirclesEdge.Audio
{
    public class ButtonAudioPlayer : AudioPlayer
    {
        [SerializeField] AudioClip clickSound;

        public void Play() => Play(clickSound);
    }
}
