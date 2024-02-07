using System;
using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class ClickingHero : IInitializable, IDisposable
    {
        private readonly HeroButtonView _heroButtonView;
        private readonly Saving _saving;
        private readonly CostHeroesConfig _config;

        public ClickingHero(HeroButtonView heroButtonView,
                            Saving saving,
                            CostHeroesConfig config)
        {
            _heroButtonView = heroButtonView;
            _saving = saving;
            _config = config;
        }

        private void OnClick()
        {
            if (_config.Get(YandexGame.savesData.NextHeroIndex) > YandexGame.savesData.Money)
            {
                YandexGame.savesData.Money++;
                _saving.Save();
            }
        }

        public void Initialize()
        {
            _heroButtonView.Pressed += OnClick;
        }

        public void Dispose()
        {
            _heroButtonView.Pressed -= OnClick;
        }
    }
}
