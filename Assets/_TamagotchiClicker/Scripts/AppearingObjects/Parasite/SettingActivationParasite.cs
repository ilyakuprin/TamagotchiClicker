using System;
using Zenject;

namespace TamagotchiClicker
{
    public class SettingActivationParasite : IInitializable, IDisposable
    {
        private readonly ParasiteView _parasiteView;
        private readonly ClickingParasite _clickingParasite;
        private readonly AppearanceParasite _appearanceParasite;

        public SettingActivationParasite(ParasiteView parasiteView,
                                         ClickingParasite clickingParasite,
                                         AppearanceParasite appearanceParasite)
        {
            _parasiteView = parasiteView;
            _clickingParasite = clickingParasite;
            _appearanceParasite = appearanceParasite;
        }

        public void Initialize()
        {
            _appearanceParasite.TimePassed += Enable;
            _clickingParasite.ClicksCompleted += Disable;
        }

        private void Enable()
            => SetActive(true);

        private void Disable()
            => SetActive(false);

        private void SetActive(bool value)
            => _parasiteView.RectTransformParasite.gameObject.SetActive(value);

        public void Dispose()
        {
            _appearanceParasite.TimePassed -= Enable;
            _clickingParasite.ClicksCompleted -= Disable;
        }
    }
}
