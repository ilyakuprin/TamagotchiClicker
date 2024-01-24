using System;
using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class ClickingHero : IInitializable, IDisposable
    {
        private readonly HeroButtonView _heroButtonView;
        private readonly Saving _saving;

        public ClickingHero(HeroButtonView heroButtonView,
                            Saving saving)
        {
            _heroButtonView = heroButtonView;
            _saving = saving;
        }

        private void OnClick()
        {
            YandexGame.savesData.ClickCount++;
            UnityEngine.Debug.Log(YandexGame.savesData.ClickCount);
        }

        private void OnSave()
            => _saving.OnSave();

        public void Initialize()
        {
            _heroButtonView.Pressed += OnClick;
            _heroButtonView.Pressed += OnSave;
        }

        public void Dispose()
        {
            _heroButtonView.Pressed -= OnClick;
            _heroButtonView.Pressed -= OnSave;
        }
    }
}
