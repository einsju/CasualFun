using UnityEngine;
using UnityEngine.UI;

namespace CasualFun.Games.OrbitratorAndCollector
{
    public class TextFade : MonoBehaviour
    {
        [SerializeField] float time = 0.5f;
        [HideInInspector] public Text text;

        [SerializeField] Color
            defaultColor = Color.white,
            targetColor = Color.white;

        void Update()
        {
            var t = Mathf.PingPong(Time.time * time, 1.0f);
            text.color = Color.Lerp(defaultColor, targetColor, t);
        }
    }
}
