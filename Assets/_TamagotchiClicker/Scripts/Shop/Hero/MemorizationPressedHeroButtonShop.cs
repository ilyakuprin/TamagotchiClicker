using System;
using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class MemorizationPressedHeroButtonShop : IInitializable, IDisposable
    {
        private readonly HeroMatching _heroMatching;
        private readonly Saving _saving;

        public MemorizationPressedHeroButtonShop(HeroMatching heroMatching,
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
                var index = i;
                var hero = _heroMatching.Get(index);
                hero.Buy.onClick.AddListener(() => Save(index));
            }
        }

        private void UnsubscribeOnBuyButton()
        {
            for (var i = 0; i < _heroMatching.GetLength(); i++)
            {
                var index = i;
                var hero = _heroMatching.Get(index);
                hero.Buy.onClick.RemoveListener(() => Save(index));
            }
        }

        private void Save(int index)
        {
            YandexGame.savesData.IndexSelectedHero = index;
            _saving.Save();
        }

        public void Dispose()
            => UnsubscribeOnBuyButton();
    }
}
