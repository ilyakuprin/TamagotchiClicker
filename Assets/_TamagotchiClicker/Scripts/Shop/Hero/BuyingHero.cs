using System;
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
            => SubscribeAllBuyButton();

        private void SubscribeAllBuyButton()
        {
            for (var i = YandexGame.savesData.NextHeroIndex; i < _heroMatching.GetLength(); i++)
            {
                var hero = _heroMatching.Get(i);
                hero.Buy.onClick.AddListener(Buy);
            }
        }

        private void Buy()
        {
            Unsubscribe(YandexGame.savesData.NextHeroIndex);
            ActivateHeroInShop();
            ChangeSaveData();
        }

        private void Unsubscribe(int index)
        {
            var hero = _heroMatching.Get(index);
            hero.Buy.onClick.RemoveListener(Buy);
        }

        private void ActivateHeroInShop()
        {
            var hero = _heroMatching.Get(YandexGame.savesData.NextHeroIndex);
            hero.Image.sprite = hero.Active;
        }

        private void ChangeSaveData()
        {
            YandexGame.savesData.Money = 0;
            YandexGame.savesData.NextHeroIndex++;
            _saving.Save();
        }

        public void Dispose()
            => UnsubscribeAllBuyButton();

        private void UnsubscribeAllBuyButton()
        {
            for (var i = YandexGame.savesData.NextHeroIndex; i < _heroMatching.GetLength(); i++)
            {
                Unsubscribe(i);
            }
        }
    }
}
