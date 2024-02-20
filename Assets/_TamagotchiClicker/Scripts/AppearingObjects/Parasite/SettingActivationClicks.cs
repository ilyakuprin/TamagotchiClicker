using System;
using Zenject;

namespace TamagotchiClicker
{
    public class SettingActivationClicks : IInitializable, IDisposable
    {
        private readonly AppearanceParasite _appearanceParasite;
        private readonly HeroView _hero;
        private readonly Autoclick _autoclick;
        private readonly ClickingParasite _clickingParasite;

        public SettingActivationClicks(AppearanceParasite appearanceParasite,
                               HeroView hero,
                               Autoclick autoclick,
                               ClickingParasite clickingParasite)
        {
            _appearanceParasite = appearanceParasite;
            _hero = hero;
            _autoclick = autoclick;
            _clickingParasite = clickingParasite;
        }

        public void Initialize()
        {
            _appearanceParasite.TimePassed += Disable;
            _clickingParasite.ClicksCompleted += Enable;
        }

        private void Disable()
        {
            _hero.DisableButton();
            _autoclick.Dispose();
        }

        private void Enable()
        {
            _hero.EnableButton();
            _autoclick.Initialize();
        }

        public void Dispose()
        {
            _appearanceParasite.TimePassed -= Disable;
            _clickingParasite.ClicksCompleted -= Enable;
        }
    }
}
