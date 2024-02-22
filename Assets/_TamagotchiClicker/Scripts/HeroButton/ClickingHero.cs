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

        private ulong _nextHeroCost;

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
            _nextHeroCost = _config.Get(YandexGame.savesData.NextHeroIndex);

            if (IsLessMax(YandexGame.savesData.Money))
            {
                YandexGame.savesData.Money += _calculationClick.Calculate();

                CheckNoMoreMax();

                _saving.Save();
            }
        }

        public void AddMoney(ulong value)
        {
            _nextHeroCost = _config.Get(YandexGame.savesData.NextHeroIndex);

            if (IsLessMax(value + YandexGame.savesData.Money))
            {
                YandexGame.savesData.Money += value;

                CheckNoMoreMax();

                _saving.Save();
            }
        }

        private bool IsLessMax(ulong value)
            => (_nextHeroCost > value);

        private void CheckNoMoreMax()
        {
            if (_nextHeroCost < YandexGame.savesData.Money)
            {
                YandexGame.savesData.Money = _nextHeroCost;
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
