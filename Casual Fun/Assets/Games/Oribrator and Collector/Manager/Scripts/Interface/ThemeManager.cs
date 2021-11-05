using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CasualFun.Games.OrbitratorAndCollector
{
    public class ThemeManager : MonoBehaviour
    {
        [Serializable]
        public class Theme
        {
            public
                Color
                backgroundColor,
                fontColor,
                spriteColor;
        }

        public Theme[] themes;

        public Material
            backgroundMat,
            fontMat,
            spriteMat;

        [HideInInspector] public int i;
        static readonly int Color1 = Shader.PropertyToID("_Color");

        void Awake()
        {
            RandomTheme();
        }

        public void RandomTheme()
        {
            i = Random.Range
                (0, themes.Length);
            SetTheme();
        }

        void SetTheme()
        {
            backgroundMat.SetColor(Color1, themes[i].backgroundColor);
            fontMat.SetColor(Color1, themes[i].fontColor);
            spriteMat.SetColor(Color1, themes[i].spriteColor);
        }

        public void OnLose()
        {
            backgroundMat.SetColor(Color1, Color.gray);
        }

    }
}