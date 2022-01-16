using CasualFun.AtCirclesEdge.Audio;
using CasualFun.AtCirclesEdge.Storage;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Screens
{
    public class Menu : MonoBehaviour
    {
        public void OnToggleSound()
        {
            var hasAudio = Preferences.HasAudio;
            
            Preferences.SetAudio(!hasAudio);
            AudioEventHandler.OnSoundOptionChanged(!hasAudio);
        }

        public void OnToggleMusic()
        {
            var hasMusic = Preferences.HasMusic;
            
            Preferences.SetMusic(!hasMusic);
            AudioEventHandler.OnMusicOptionChanged(!hasMusic);
        }
        
        public void OnOptions() => SceneLoader.LoadScene("_Options");

        public void OnStore() => SceneLoader.LoadScene("_Store");

        public void OnLevels() => SceneLoader.LoadScene("_Levels");

        public void OnLeaderboard() => SceneLoader.LoadScene("_Leaderboard");
    }
}
