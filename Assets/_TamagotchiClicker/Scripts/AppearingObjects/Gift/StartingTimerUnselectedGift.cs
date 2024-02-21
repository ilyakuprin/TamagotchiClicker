using System;
using Zenject;

namespace TamagotchiClicker
{
    public class StartingTimerUnselectedGift : IInitializable, IDisposable
    {
        private readonly Appearance _appearance;
        private readonly SettingActivationGift _settingActivationGift;
        private readonly MovingGift _movingGift;

        public StartingTimerUnselectedGift(AppearanceGift appearance,
                                           SettingActivationGift settingActivationGift,
                                           MovingGift movingGift)
        {
            _appearance = appearance;
            _settingActivationGift = settingActivationGift;
            _movingGift = movingGift;
        }

        public void Initialize()
            => _movingGift.MovementOver += StartTimer;

        private void StartTimer()
        {
            if (_settingActivationGift.GetActive)
                _appearance.Initialize();
        } 

        public void Dispose()
            => _movingGift.MovementOver -= StartTimer;
    }
}
