using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace TamagotchiClicker
{
    [Serializable]
    public struct Hero
    {
        public Image Image;
        public Button Buy;
        public Sprite NotActive;
        public Sprite Active;
        public Sprite Background;
    }

    public class HeroMatching : MonoBehaviour
    {
        [SerializeField] private Hero[] _hero;

        public Hero Get(int index)
            => _hero[index];

        public int GetLength()
            => _hero.Length;

        private void Awake()
            => Show();

        private void Show()
        {
            for (var i = YandexGame.savesData.NextHeroIndex; i < _hero.Length; i++)
            {
                var hero = _hero[i];

                hero.Buy.interactable = false;
                hero.Image.sprite = hero.NotActive;
            }
        }
    }
}
