using System;
using UnityEngine.UI;
using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class ActivatingHeroBuyButton : IInitializable, IDisposable
    {
        private readonly HeroMatching _heroMatching;
        private readonly Saving _saving;
        private readonly CostHeroesConfig _config;

        private Button _button;

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
                _button = _heroMatching.Get(index).Buy;

                if (YandexGame.savesData.Money >= _config.Get(index))
                {
                    SetInteractable(true);
                }
                else
                {
                    SetInteractable(false);
                }
            }
            else
            {
                Dispose();
            }
        }

        private void SetInteractable(bool value)
            => _button.interactable = value;

        public void Dispose()
            => _saving.SaveDataReceived -= Activate;
    }
}
