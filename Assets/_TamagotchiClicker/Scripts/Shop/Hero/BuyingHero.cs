using System;
using UnityEngine;
using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class BuyingHero : IInitializable, IDisposable
    {
        private readonly HeroMatching _heroMatching;
        private readonly Saving _saving;

        public BuyingHero(HeroMatching heroMatching,
                          Saving saving)
        {
            _heroMatching = heroMatching;
            _saving = saving;

        }

        public void Initialize()
            => SubscribeOnBuyButton();

        private void SubscribeOnBuyButton()
        {
            for (var i = 0; i < _heroMatching.GetLength(); i++)
            {
                var hero = _heroMatching.Get(i);
                hero.Buy.onClick.AddListener(ChangeSaveData);
            }
        }

        private void ChangeSaveData()
        {
            YandexGame.savesData.Money = 0;
            YandexGame.savesData.NextHeroIndex++;

            _saving.Save();
        }

        public void Dispose()
            => UnsubscribeOnBuyButton();

        private void UnsubscribeOnBuyButton()
        {
            for (var i = 0; i < _heroMatching.GetLength(); i++)
            {
                var hero = _heroMatching.Get(i);
                hero.Buy.onClick.RemoveListener(ChangeSaveData);
            }
        }
    }
}
