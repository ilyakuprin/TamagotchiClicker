using System;
using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class BuyingBoost : IInitializable, IDisposable
    {
        private readonly BoostMatching _boostMatching;
        private readonly BoostsValueConfig _config;
        private readonly Saving _saving;

        public BuyingBoost(BoostMatching boostMatching,
                            BoostsValueConfig config,
                            Saving saving)
        {
            _boostMatching = boostMatching;
            _config = config;
            _saving = saving;
        }

        public void Initialize()
        {
            ShowStartValues();
            SubscribeAllBuyButton();
        }

        private void ShowStartValues()
        {
            for (var i = 0; i < _boostMatching.GetLength(); i++)
            {
                ShowPrice(i, CalculatePrice(i));
            }
        }

        private ulong CalculatePrice(int index)
        {
            double improvement = _config.GetImprovement(index) * YandexGame.savesData.NumberImprovements[index];
            var startCost = _config.GetCost(index);
            var itogCost = startCost + startCost * improvement;
            return (ulong)Math.Ceiling(itogCost);
        }

        private void ShowPrice(int index, ulong price)
        {
            var boost = _boostMatching.Get(index);
            boost.Price.text = price.ToString();
        }

        private void SubscribeAllBuyButton()
        {
            for (var i = 0; i < _boostMatching.GetLength(); i++)
            {
                var boost = _boostMatching.Get(i);
                var index = i;
                boost.Buy.onClick.AddListener(() => Buy(index));
            }
        }

        private void Buy(int index)
        {
            YandexGame.savesData.Money -= CalculatePrice(index);

            YandexGame.savesData.NumberImprovements[index]++;
            ShowPrice(index, CalculatePrice(index));

            _saving.Save();
        }

        public void Dispose()
            => UnsubscribeAllBuyButton();

        private void UnsubscribeAllBuyButton()
        {
            for (var i = 0; i < _boostMatching.GetLength(); i++)
            {
                var boost = _boostMatching.Get(i);
                var index = i;
                boost.Buy.onClick.RemoveListener(() => Buy(index));
            }
        }
    }
}
