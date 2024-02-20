using System;
using Zenject;

namespace TamagotchiClicker
{
    public class SettingActivationClicks : IInitializable, IDisposable
    {
        private readonly AppearanceParasite _appearanceParasite;
        private readonly HeroView _hero;
        private readonly Autoclick _autoclick;

        public SettingActivationClicks(AppearanceParasite appearanceParasite,
                               HeroView hero,
                               Autoclick autoclick)
        {
            _appearanceParasite = appearanceParasite;
            _hero = hero;
            _autoclick = autoclick;
        }

        public void Initialize()
        {
            _appearanceParasite.TimePassed += Disable;
        }

        private void Disable()
        {
            _hero.DisableButton();
            _autoclick.Dispose();
        }

        public void Dispose()
        {
            _appearanceParasite.TimePassed -= Disable;
        }
    }
}
