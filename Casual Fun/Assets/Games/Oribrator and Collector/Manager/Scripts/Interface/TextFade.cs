using UnityEngine;
using TMPro;

namespace CasualFun.Games.OrbitratorAndCollector
{
    public class TextFade : MonoBehaviour
    {
        [HideInInspector] public TextMeshProUGUI text;
        // [SerializeField] float time = 0.5f;
        // [SerializeField] Color32 defaultColor = Color.white;
        // [SerializeField] Color32 targetColor = Color.white;

        // void Update()
        // {
        //     var t = Mathf.PingPong(Time.time * time, 1.0f);
        //     text.color = Color.Lerp(defaultColor, targetColor, t);
        // }
    }
}
