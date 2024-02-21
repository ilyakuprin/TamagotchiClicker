using System;
using Zenject;

namespace TamagotchiClicker
{
    public class ClickingParasite : IInitializable, IDisposable
    {
        public event Action ClicksCompleted;

        private readonly ParasiteView _parasiteView;
        private readonly ParasiteConfig _parasiteConfig;
        private readonly AppearanceParasite _appearance;

        private int _counterClick;

        public ClickingParasite(ParasiteView parasiteView,
                                ParasiteConfig parasiteConfig,
                                AppearanceParasite appearance)
        {
            _parasiteView = parasiteView;
            _parasiteConfig = parasiteConfig;
            _appearance = appearance;
        }

        public void Initialize()
        {
            _parasiteView.Pressed += Click;
        }

        private void Click()
        {
            _counterClick++;

            if (_counterClick == _parasiteConfig.NumberClicks)
            {
                DriveAwayParasite();
            }
        }

        public void DriveAwayParasite()
        {
            ClicksCompleted?.Invoke();

            StartTimer();
            ResetClicks();
        }

        private void StartTimer()
            => _appearance.Initialize();

        private void ResetClicks()
            => _counterClick = 0;

        public void Dispose()
        {
            _parasiteView.Pressed -= Click;
        }
    }
}
