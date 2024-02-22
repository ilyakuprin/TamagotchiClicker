using System;
using UnityEngine;
using Zenject;

namespace TamagotchiClicker
{
    public class ChangingHeroOnScreen : IInitializable, IDisposable
    {
        private readonly HeroMatching _heroMatching;
        private readonly HeroView _mainHero;

        public ChangingHeroOnScreen(HeroMatching heroMatching,
                                    HeroView mainHero)
        {
            _heroMatching = heroMatching;
            _mainHero = mainHero;
        }

        public void Initialize()
            => SubscribeOnBuyButton();

        private void SubscribeOnBuyButton()
        {
            for (var i = 0; i < _heroMatching.GetLength(); i++)
            {
                var hero = _heroMatching.Get(i);
                var spriteHero = hero.Active;
                hero.Buy.onClick.AddListener(() => ChangeSprite(spriteHero));
            }
        }

        private void UnsubscribeOnBuyButton()
        {
            for (var i = 0; i < _heroMatching.GetLength(); i++)
            {
                var hero = _heroMatching.Get(i);
                var spriteHero = hero.Active;
                hero.Buy.onClick.RemoveListener(() => ChangeSprite(spriteHero));
            }
        }

        public void ChangeSprite(Sprite spriteHero)
        {
            _mainHero.ImageHero.sprite = spriteHero;
            _mainHero.ImageHero.SetNativeSize();
        }

        public void Dispose()
            => UnsubscribeOnBuyButton();
    }
}
