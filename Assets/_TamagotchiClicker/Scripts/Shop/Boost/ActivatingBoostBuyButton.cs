using System;
using UnityEngine.UI;
using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class ActivatingBoostBuyButton : IInitializable, IDisposable
    {
        private readonly BoostMatching _boostMatching;
        private readonly BoostsValueConfig _config;
        private readonly Saving _saving;

        private Button _button;

        public ActivatingBoostBuyButton(BoostsValueConfig config,
                                        BoostMatching boostMatching,
                                        Saving saving)
        {
            _config = config;
            _boostMatching = boostMatching;
            _saving = saving;
        }

        public void Initialize()
            => _saving.SaveDataReceived += Activate;

        private void Activate()
        {
            for (var i = 0; i < YandexGame.savesData.CurrentBoostIndex + 1; i++)
            {
                _button = _boostMatching.Get(i).Buy;

                if (YandexGame.savesData.Money >= _config.GetCost(i))
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
