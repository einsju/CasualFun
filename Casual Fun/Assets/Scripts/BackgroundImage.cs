using CasualFun.AtCirclesEdge.Storage;
using UnityEngine;
using UnityEngine.UI;

namespace CasualFun.AtCirclesEdge
{
    public class BackgroundImage : MonoBehaviour
    {
        [SerializeField] Sprite day;
        [SerializeField] Sprite night;

        Image _image;

        void Awake()
        {
            _image = GetComponent<Image>();
            _image.sprite = Preferences.UseLightMood ? day : night;
        }
    }
}
