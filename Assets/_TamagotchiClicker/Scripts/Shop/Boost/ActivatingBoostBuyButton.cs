using System;
using UnityEngine.UI;
using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class ActivatingBoostBuyButton : IInitializable, IDisposable
    {
        private readonly BoostMatching _boostMatching;
        private readonly BuyingBoost _buyingBoost;
        private readonly Saving _saving;

        private Button _button;

        public ActivatingBoostBuyButton(BuyingBoost buyingBoost,
                                        BoostMatching boostMatching,
                                        Saving saving)
        {
            _buyingBoost = buyingBoost;
            _boostMatching = boostMatching;
            _saving = saving;
        }

        public void Initialize()
            => _saving.SaveDataReceived += Activate;

        private void Activate()
        {
            var lastIndex = YandexGame.savesData.CurrentBoostIndex + 1;
            var length = _boostMatching.GetLength();

            if (lastIndex > length)
            {
                lastIndex = length;
            }

            for (var i = 0; i < lastIndex; i++)
            {
                _button = _boostMatching.Get(i).Buy;

                if (YandexGame.savesData.Money >= _buyingBoost.CalculatePrice(i))
                {
                    SetInteractable(true);
                }
                else
                {
                    SetInteractable(false);
                }
            }
        }

        private void SetInteractable(bool value)
            => _button.interactable = value;

        public void Dispose()
            => _saving.SaveDataReceived -= Activate;
    }
}
