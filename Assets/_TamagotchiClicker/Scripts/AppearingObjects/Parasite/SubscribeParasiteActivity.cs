using System;
using Zenject;

namespace TamagotchiClicker
{
    public class SubscribeParasiteActivity : IInitializable, IDisposable
    {
        private readonly AppearanceParasite _appearance;
        private readonly ClickingParasite _clickingParasite;
        private readonly ParasiteActivity _parasiteActivity;

        public SubscribeParasiteActivity(AppearanceParasite appearance,
                                         ClickingParasite clickingParasite,
                                         ParasiteActivity parasiteActivity)
        {
            _appearance = appearance;
            _clickingParasite = clickingParasite;
            _parasiteActivity = parasiteActivity;
        }

        public void Initialize()
        {
            _appearance.TimePassed += _parasiteActivity.StartActivity;
            _clickingParasite.ClicksCompleted += _parasiteActivity.StopActivity;
        }

        public void Dispose()
        {
            _appearance.TimePassed -= _parasiteActivity.StartActivity;
            _clickingParasite.ClicksCompleted -= _parasiteActivity.StopActivity;
        }
    }
}
