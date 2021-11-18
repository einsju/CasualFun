using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

namespace CasualFun.Games.AtCirclesEdgeAndInBetween
{
    public sealed class Store : MonoBehaviour
    {
        [SerializeField] SpriteRenderer player;

        [Header("Button")] Sprite _coinsImage;
        [HideInInspector] public Image[] buttonBackground;

        [SerializeField] Color 
            unlockColor = Color.white,
            lockColor = Color.grey;

        [SerializeField] Button[] buttons;

        [HideInInspector] public Text[] buttonsTexts;
        [HideInInspector] public Image[] buttonsImage;

        [Header("Scenes  References")] Text _coinsText;
        Toggle _randomToggle;

        [HideInInspector] public GameObject container;

        int _coins,
            _index,
            _isRandom = 1,
            _startedButtonIndex;

        const int ButtonsPerPage = 10;

        [HideInInspector] public int[] prices;

        string _have;

        [HideInInspector] public string[] data;

        [Header("Items")] public Sprite[] icon;
        public bool hide;

        int CurrentIndex()
        {
            return _index % 10;
        }

        static int GetPageIndex(int x)
        {
            if (x < 11) return 0;
            while (x >= 10)
            {
                x /= 10;
            }

            var d = Convert.ToInt32($"{x}{0}");
            return d;
        }

        private void Start()
        {
            GetRefer();
            CheckSave();
            Initialize();
        }

        void GetRefer()
        {
            _coinsText = GameObject.FindGameObjectWithTag("coinsText").GetComponent<Text>();
            _randomToggle = GameObject.FindGameObjectWithTag("RandomPlayerToggle").GetComponent<Toggle>();
            container = GameObject.FindGameObjectWithTag("storeContainer");
            _coinsImage = buttonsImage[0].sprite;
        }

        IEnumerator WaitPlayer()
        {
            yield return new WaitUntil(() => player != null);
            SettingPlayer();
            SetPlayer(_index);
            RandomizePlayer();
        }

        void CheckSave()
        {
            _index = PlayerPrefs.GetInt(data[1]);
            _coins = PlayerPrefs.GetInt(data[0]);
            _coinsText.text = _coins.ToString();
            if (PlayerPrefs.HasKey(data[3]))
            {
                _have = PlayerPrefs.GetString(data[3]);
            }
            else
            {
                _have = icon[0].name;
                PlayerPrefs.SetString(data[3], _have);
            }
        }

        void Initialize()
        {
            SetToggle();
            StartCoroutine(WaitPlayer());
            SetLevelButtons(0);
        }

        public void OnOpenLevelMenu()
        {
            var x = GetPageIndex(_index);
            if (x == CurrentIndex()) return;
            SetLevelButtons(x);
        }

        void SetLevelButtons(int current)
        {
            _startedButtonIndex = current;
            
            for (var i = 0; i < buttons.Length; i++)
            {
                if (_startedButtonIndex + i >= icon.Length)
                {
                    buttons[i].gameObject.SetActive(false);
                }
                else if (!buttons[i].gameObject.activeSelf)
                {
                    buttons[i].gameObject.SetActive(true);
                }

                var cIndex = i + _startedButtonIndex;
                if (cIndex < icon.Length)
                {
                    if (!buttons[i].gameObject.activeSelf) buttons[i].gameObject.SetActive(true);
                    if (_have.Contains(icon[cIndex].name))
                    {
                        buttonBackground[i].color = unlockColor;
                        buttonsImage[i].sprite = icon[cIndex];
                        buttonsTexts[i].text = null;
                    }
                    else
                    {
                        buttonBackground[i].color = lockColor;
                        buttonsImage[i].sprite = _coinsImage;
                        buttonsTexts[i].text = prices[cIndex].ToString();
                    }
                }
                else
                {
                    buttons[i].gameObject.SetActive(false);
                }
            }
        }

        public void SwipeButtons(int delta)
        {
            int n;
            if (delta < 0) n = -ButtonsPerPage;
            else n = ButtonsPerPage;
            n += _startedButtonIndex;
            if (n >= icon.Length) n = _startedButtonIndex = 0;
            else if (n < 0) n = _startedButtonIndex = GetPageIndex(icon.Length - ButtonsPerPage);
            SetLevelButtons(n);
        }

        public void Buy(int i)
        {
            var x = i + _startedButtonIndex;
            print(x);
            if (_have.Contains(icon[x].name))
            {
                Chance(x);
            }
            else
            {
                var p = int.Parse(buttonsTexts[i].text);
                if (_coins < p) return;

                _coins -= p;
                _coinsText.text = _coins.ToString();

                buttonBackground[i].color = unlockColor;
                buttonsImage[i].sprite = icon[x];
                buttonsTexts[i].text = null;

                _index = x;
                _have += icon[x].name + ",";
                SetPlayer(x);

                PlayerPrefs.SetInt(data[1], _index);
                PlayerPrefs.SetInt(data[0], _coins);
                PlayerPrefs.SetString(data[3], _have);
            }
        }

        public void Select()
        {
            var button = EventSystem.current.currentSelectedGameObject;
            var i = int.Parse(button.name);
            Chance(i);
        }

        void Chance(int i)
        {
            SetPlayer(i);
            _index = i;
            PlayerPrefs.SetInt(data[1], _index);
            //Hide Shopping after set the sprite
            if (!hide) return;
            print("hide shop");
        }

        void SetPlayer(int i)
        {
            player.sprite = icon[i];
        }

        void SettingPlayer()
        {

        }

        void SetToggle()
        {
            _isRandom = PlayerPrefs.GetInt(data[2]);
            _randomToggle.isOn = _isRandom == 1;
        }

        public void ToggleRandom()
        {
            var enable = _randomToggle.isOn;
            if (enable)
            {
                _isRandom = 1;
            }
            else
            {
                _isRandom = 0;
                PlayerPrefs.SetInt(data[1], _index);
            }

            PlayerPrefs.SetInt(data[2], _isRandom);
        }

        public void RandomizePlayer()
        {
            // 0 = false 1 = true
            if (_isRandom != 1) return;
            var allItems = new List<int>();
            for (var i = 0; i < data.Length; i++)
            {
                if (_have.Contains(icon[i].name))
                {
                    allItems.Add(i);
                }
            }

            _index = allItems[Random.Range(0, allItems.Count)];
            SetPlayer(_index);
        }

        public void SaveCoins(int c)
        {
            _coins += c;
            _coinsText.text = _coins.ToString();
            PlayerPrefs.SetInt(data[0], _coins);
        }
    }
}
