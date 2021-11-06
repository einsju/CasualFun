using UnityEngine;
using UnityEngine.UI;

namespace CasualFun.Games.OrbitratorAndCollector
{
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] Canvas[] canvas;

        public static CanvasManager Inst;
        
        int _currentEnabled;

        void Awake() => Inst = this;

        void Start()
        {
            var buttons = GameObject.FindGameObjectsWithTag("BackButton");
            var b = new Button[buttons.Length];
            for (var i = 0; i < buttons.Length; i++)
            {
                b[i] = buttons[i].GetComponent<Button>();
                b[i].onClick.AddListener(OpenMainMenu);
            }
        }

        public void ShowCanvas(int i)
        {
            if (canvas[i].isActiveAndEnabled)
            {
                canvas[i].enabled = false;
            }
            else
            {
                canvas[i].enabled = true;
                _currentEnabled = i;
            }
        }

        void OpenMainMenu()
        {
            ShowCanvas(_currentEnabled);
            if (canvas[0].isActiveAndEnabled) return;
            ShowCanvas(0);
        }

        public void OpenUrls(string url) => Application.OpenURL(url);
    }
}
