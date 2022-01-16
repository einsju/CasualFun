using UnityEngine;

namespace CasualFun.AtCirclesEdge.Audio
{
    public class GameAudioPlayer : AudioPlayer
    {
        [SerializeField] AudioClip itemCollectedSound;
        [SerializeField] AudioClip gameOverSound;

        public void PlayItemCollectedSound() => Play(itemCollectedSound);
        
        public void PlayGameOverSound() => Play(gameOverSound);
    }
}
