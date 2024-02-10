using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace TamagotchiClicker
{
    [Serializable]
    public struct Boost
    {
        public Image Image;
        public Button Buy;
        public Sprite NotActive;
        public Sprite Active;
        public TextMeshProUGUI Price;
    }

    public class BoostMatching : MonoBehaviour
    {
        [SerializeField] private Boost[] _boosts;

        public Boost Get(int index)
            => _boosts[index];

        public int GetLength()
            => _boosts.Length;

        private void Awake()
            => Show();

        private void Show()
        {
            for (var i = YandexGame.savesData.CurrentBoostIndex; i < _boosts.Length; i++)
            {
                var hero = _boosts[i];

                hero.Buy.interactable = false;
                hero.Image.sprite = hero.NotActive;
            }
        }
    }
}
