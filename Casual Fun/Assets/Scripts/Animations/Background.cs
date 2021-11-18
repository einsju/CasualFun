using System.Collections;
using CasualFun.Handlers;
using CasualFun.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace CasualFun.Animations
{
    public class Background : MonoBehaviour
    {
        [SerializeField] float duration = 0.4f;
        
        float DestinationX => transform.localPosition.x > 0 ? -400f : 400f;
        Vector2 Destination => new Vector2(DestinationX, transform.localPosition.y);

        void Awake()
        {
            GameStateEventHandler.GameOver += GameOver;
        }

        void OnDestroy()
        {
            GameStateEventHandler.GameOver -= GameOver;
        }

        void GameOver()
        {
            var image = GetComponent<Image>();
        }

        void OnEnable() => EventManager.ScreenOpened += ScreenOpened;
        void OnDisable() => EventManager.ScreenOpened -= ScreenOpened;

        void ScreenOpened() => transform.LeanMoveLocalX(Destination.x, duration).setEaseOutCirc();
    }
}
