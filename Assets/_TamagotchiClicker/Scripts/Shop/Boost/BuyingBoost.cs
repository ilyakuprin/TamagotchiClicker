using System;
using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class BuyingBoost : IInitializable, IDisposable
    {
        public event Action Bought;

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

        public ulong CalculatePrice(int index)
        {
            double improvement = _config.GetImprovement(index) * YandexGame.savesData.NumberImprovements[index];
            var startCost = _config.GetCost(index);
            var itogCost = startCost + startCost * improvement;
            return (ulong)Math.Ceiling(itogCost);
        }

        private void ShowPrice(int index, ulong price)
        {
            var boost = _boostMatching.Get(index);
            boost.Price.text = NumberFormat.GetFormattedString(price);
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
            SubtractMoney(index);
            UpImprovement(index);
            UpClick(index);

            _saving.Save();

            Bought?.Invoke();
        }

        private void SubtractMoney(int index)
            => YandexGame.savesData.Money -= CalculatePrice(index);

        private void UpImprovement(int index)
        {
            YandexGame.savesData.NumberImprovements[index]++;
            ShowPrice(index, CalculatePrice(index));
        }

        private void UpClick(int index)
            => YandexGame.savesData.ClickValue += _config.GetGainImprovement(index);

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
