using UnityEngine;

namespace CasualFun
{
    public class CameraBoundsInitializer : MonoBehaviour
    {
        [SerializeField] Camera mainCamera;
        [SerializeField] float cameraOffset = 8;
        [SerializeField] Renderer origin;
        
        float Bounds => origin.bounds.size.x * Screen.height / Screen.width * cameraOffset;

        void Start() => mainCamera.orthographicSize = Bounds;
    }
}
