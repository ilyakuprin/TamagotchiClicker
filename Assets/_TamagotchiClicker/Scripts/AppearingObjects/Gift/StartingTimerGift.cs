using System;
using Zenject;

namespace TamagotchiClicker
{
    public class StartingTimerGift : IInitializable, IDisposable
    {
        private readonly Appearance _appearance;
        private readonly GiftView _giftView;

        public StartingTimerGift(AppearanceGift appearance,
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
