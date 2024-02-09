using System;
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
    }

    public class BoostMatching : MonoBehaviour
    {
        [SerializeField] private Boost[] _boosts;

        private void Awake()
            => Show();

        private void Show()
        {
            for (var i = YandexGame.savesData.NextBoostIndex; i < _boosts.Length; i++)
            {
                var hero = _boosts[i];

                hero.Buy.interactable = false;
                hero.Image.sprite = hero.NotActive;
            }
        }
    }
}
