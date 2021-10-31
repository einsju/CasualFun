using CasualFun.Handlers;
using UnityEngine;

namespace CasualFun
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] AudioClip audioClip;

        protected void PlaySound() => AudioEventHandler.OnPlaySound(audioClip);
    }
}
