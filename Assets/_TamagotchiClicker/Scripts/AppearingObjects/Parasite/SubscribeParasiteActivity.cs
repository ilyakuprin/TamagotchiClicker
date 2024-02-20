using System;
using Zenject;

namespace TamagotchiClicker
{
    public class SubscribeParasiteActivity : IInitializable, IDisposable
    {
        private readonly AppearanceParasite _appearanceParasite;
        private readonly ClickingParasite _clickingParasite;
        private readonly ParasiteActivity _parasiteActivity;

        public SubscribeParasiteActivity(AppearanceParasite appearanceParasite,
                                         ClickingParasite clickingParasite,
                                         ParasiteActivity parasiteActivity)
        {
            _appearanceParasite = appearanceParasite;
            _clickingParasite = clickingParasite;
            _parasiteActivity = parasiteActivity;
        }

        public void Initialize()
        {
            _appearanceParasite.TimePassed += _parasiteActivity.StartActivity;
            _clickingParasite.ClicksCompleted += _parasiteActivity.StopActivity;
        }

        public void Dispose()
        {
            _appearanceParasite.TimePassed -= _parasiteActivity.StartActivity;
            _clickingParasite.ClicksCompleted -= _parasiteActivity.StopActivity;
        }
    }
}
