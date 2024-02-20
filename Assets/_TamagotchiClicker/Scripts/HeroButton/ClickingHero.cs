using System;
using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class ClickingHero : IInitializable, IDisposable
    {
        private readonly HeroView _heroView;
        private readonly Saving _saving;
        private readonly CostHeroesConfig _config;
        private readonly CalculationClick _calculationClick;

        public ClickingHero(HeroView heroView,
                            Saving saving,
                            CostHeroesConfig config,
                            CalculationClick calculationClick)
        {
            _heroView = heroView;
            _saving = saving;
            _config = config;
            _calculationClick = calculationClick;
        }

        public void OnAddMoney()
        {
            var nextHeroCost = _config.Get(YandexGame.savesData.NextHeroIndex);

            if (nextHeroCost > YandexGame.savesData.Money)
            {
                YandexGame.savesData.Money += _calculationClick.Calculate();

                if (nextHeroCost < YandexGame.savesData.Money)
                {
                    YandexGame.savesData.Money = nextHeroCost;
                }

                _saving.Save();
            }
        }

        public void Initialize()
        {
            _heroView.Pressed += OnAddMoney;
        }

        public void Dispose()
        {
            _heroView.Pressed -= OnAddMoney;
        }
    }
}
