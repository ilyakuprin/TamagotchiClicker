using System;
using Zenject;

namespace TamagotchiClicker
{
    public class StartingTimerSelectedGift : IInitializable, IDisposable
    {
        private readonly Appearance _appearance;
        private readonly GiftView _giftView;

        public StartingTimerSelectedGift(AppearanceGift appearance,
                                 GiftView giftView)
        {
            _appearance = appearance;
            _giftView = giftView;
        }

        public void Initialize()
            => _giftView.Pressed += StartTimer;

        private void StartTimer()
            => _appearance.Initialize();

        public void Dispose()
            => _giftView.Pressed -= StartTimer;
    }
}
