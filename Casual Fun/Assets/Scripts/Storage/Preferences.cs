using UnityEngine;

namespace CasualFun.AtCirclesEdge.Storage
{
    public abstract class Preferences
    {
        const string KeyAudio = "_AUDIO_";
        const string KeyMusic = "_MUSIC_";
        const string KeyMood = "_MOOD_";

        public static bool HasAudio => PlayerPrefs.GetInt(KeyAudio, 1) == 1;
        public static void SetAudio(bool value) => PlayerPrefs.SetInt(KeyAudio, value ? 1 : 0);
        
        public static bool HasMusic => PlayerPrefs.GetInt(KeyMusic, 1) == 1;
        public static void SetMusic(bool value) => PlayerPrefs.SetInt(KeyMusic, value ? 1 : 0);

        public static bool UseLightMood => PlayerPrefs.GetInt(KeyMood, 1) == 1;
        public static void SetMood(int value) => PlayerPrefs.SetInt(KeyMood, value);
    }
}
