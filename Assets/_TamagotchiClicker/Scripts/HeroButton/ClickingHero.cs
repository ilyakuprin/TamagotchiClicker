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

        private ulong _nextHeroCost = ulong.MaxValue;

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
            _nextHeroCost = GetCost();

            if (IsLessMax(YandexGame.savesData.Money))
            {
                YandexGame.savesData.Money += _calculationClick.Calculate();

                CheckNoMoreMax();

                _saving.Save();
            }
        }

        public void AddMoney(ulong value)
        {
            _nextHeroCost = GetCost();

            if (IsLessMax(value + YandexGame.savesData.Money))
            {
                YandexGame.savesData.Money += value;

                CheckNoMoreMax();

                _saving.Save();
            }
        }

        public bool IsMoreMax()
        {
            return _nextHeroCost <= YandexGame.savesData.Money;
        }

        private bool IsLessMax(ulong value)
            => (_nextHeroCost > value);

        private void CheckNoMoreMax()
        {
            if (IsMoreMax())
            {
                YandexGame.savesData.Money = _nextHeroCost;
            }
        }

        private ulong GetCost()
        {
            var indexNext = YandexGame.savesData.NextHeroIndex;

            if (indexNext >= _config.GetLength())
            {
                return ulong.MaxValue;
            }
            else
            {
                return _config.Get(GetIndexHero());
            }
        }

        private int GetIndexHero()
        {
            var indexNext = YandexGame.savesData.NextHeroIndex;

            if (indexNext >= _config.GetLength())
                indexNext = _config.GetLength() - 1;

            return indexNext;
        }

        public void Initialize()
        {
            _nextHeroCost = GetCost();
            _heroView.Pressed += OnAddMoney;
        }

        public void Dispose()
        {
            _heroView.Pressed -= OnAddMoney;
        }
    }
}
