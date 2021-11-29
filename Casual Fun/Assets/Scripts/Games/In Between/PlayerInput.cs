using CasualFun.State;
using UnityEngine;

namespace CasualFun.Games.InBetween
{
    public class PlayerInput : GameStateBehaviour
    {
        [SerializeField] Player player;

        float _screenWidth;

        public override void Awake() => _screenWidth = Screen.width;

        void Update()
        {
            if (HasPlayerStoppedMoving())
            {
                player.StopMoving();
                return;
            }
            
            player.Move(GetDirection());
        }
        
#if !UNITY_EDITOR
        static bool HasPlayerStoppedMoving() => Input.touchCount == 0;
        
        Vector2 GetDirection() => Input.GetTouch(0).deltaPosition / _screenWidth;
#endif

#if UNITY_EDITOR
        static bool HasPlayerStoppedMoving() => !Input.GetMouseButton(0);
        
        Vector2 GetDirection() => -(_lastPosition - (Vector2) Input.mousePosition) / _screenWidth;

        Vector2 _lastPosition;
        void LateUpdate() => _lastPosition = Input.mousePosition;
#endif
     }
}
