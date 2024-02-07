using System;
using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class ActivatingHeroBuyButton : IInitializable, IDisposable
    {
        private readonly HeroMatching _heroMatching;
        private readonly Saving _saving;
        private readonly CostHeroesConfig _config;

        public ActivatingHeroBuyButton(HeroMatching heroMatching,
                                       Saving saving,
                                       CostHeroesConfig config)
        {
            _heroMatching = heroMatching;
            _saving = saving;
            _config = config;
        }

        public void Initialize()
            => _saving.SaveDataReceived += Activate;

        private void Activate()
        {
            var index = YandexGame.savesData.NextHeroIndex;

            if (_config.GetLength() > index)
            {
                if (YandexGame.savesData.Money >= _config.Get(index))
                {
                    ActivateHeroInShop(index);
                }
            }
        }

        private void ActivateHeroInShop(int index)
        {
            var hero = _heroMatching.Get(index);

            hero.Buy.interactable = true;
            hero.Image.sprite = hero.Active;
        }

        public void Dispose()
            => _saving.SaveDataReceived -= Activate;
    }
}
