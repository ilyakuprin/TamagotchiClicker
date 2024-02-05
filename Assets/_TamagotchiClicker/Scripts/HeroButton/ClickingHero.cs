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
            => YandexGame.savesData.Money++;

        private void OnSave()
            => _saving.Save();

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
