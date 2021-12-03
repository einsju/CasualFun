using System;
using System.Linq;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Audio
{
    public abstract class MusicThemeCoordinator
    {
        const int NumberOfMusicThemes = 14;
        
        static int[] musicThemes = new int[NumberOfMusicThemes];
        static int lastPlayedIndex;

        static MusicThemeCoordinator() => PreparePlayList();

        static void PreparePlayList()
        {
            InitializeThemes();
            RandomizeThemes();
        }

        static void InitializeThemes()
        {
            for (var i = 0; i < NumberOfMusicThemes; i++)
                musicThemes[i] = i + 1;
        }

        static void RandomizeThemes()
            => musicThemes = musicThemes.OrderBy(t => Guid.NewGuid()).ToArray();

        public static AudioClip GetMusicTheme()
            => Resources.Load($"Music/Theme_{NextTheme}") as AudioClip;

        static int NextTheme
            => musicThemes[Mathf.Clamp(lastPlayedIndex++, 0, NumberOfMusicThemes)];
    }
}
