using System;
using UnityEngine;
using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class OpeningNextBoost : IInitializable, IDisposable
    {
        private readonly BoostMatching _boostMatching;
        private readonly Saving _saving;

        public OpeningNextBoost(BoostMatching boostMatching,
                                Saving saving)
        {
            _boostMatching = boostMatching;
            _saving = saving;
        }

        public void Initialize()
            => SubscribeAllBuyButton();

        private void SubscribeAllBuyButton()
        {
            for (var i = YandexGame.savesData.CurrentBoostIndex; i < _boostMatching.GetLength(); i++)
            {
                var boost = _boostMatching.Get(i);
                boost.Buy.onClick.AddListener(FirstBuy);
            }
        }

        private void FirstBuy()
        {
            Unsubscribe();
            GoToNextBoost();
            ActivateNextBoost();
        }

        private void Unsubscribe()
        {
            var boost = _boostMatching.Get(YandexGame.savesData.CurrentBoostIndex);
            boost.Buy.onClick.RemoveListener(FirstBuy);
        }

        private void GoToNextBoost()
        {
            YandexGame.savesData.CurrentBoostIndex++;
            _saving.Save();
        }

        private void ActivateNextBoost()
        {
            var index = YandexGame.savesData.CurrentBoostIndex;

            if (index < _boostMatching.GetLength())
            {
                var boost = _boostMatching.Get(index);
                boost.Image.sprite = boost.Active;
            }
        }

        public void Dispose()
            => UnsubscribeAllBuyButton();

        private void UnsubscribeAllBuyButton()
        {
            for (var i = YandexGame.savesData.CurrentBoostIndex; i < _boostMatching.GetLength(); i++)
            {
                var boost = _boostMatching.Get(i);
                boost.Buy.onClick.RemoveListener(FirstBuy);
            }
        }
    }
}
