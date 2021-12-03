using UnityEngine;

namespace CasualFun.AtCirclesEdge
{
    public class CameraBoundsInitializer : MonoBehaviour
    {
        [SerializeField] float cameraOffset = 8;

        Camera _camera;

        void Awake() => _camera = Camera.main;

        void Start() => _camera.orthographicSize = Bounds;
        
        float Bounds => cameraOffset * Screen.height / Screen.width;
    }
}
