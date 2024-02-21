using System;
using Zenject;

namespace TamagotchiClicker
{
    public class SettingActivationParasite : IInitializable, IDisposable
    {
        private readonly ParasiteView _parasiteView;
        private readonly ClickingParasite _clickingParasite;
        private readonly Appearance _appearance;

        public SettingActivationParasite(ParasiteView parasiteView,
                                         ClickingParasite clickingParasite,
                                         AppearanceParasite appearance)
        {
            _parasiteView = parasiteView;
            _clickingParasite = clickingParasite;
            _appearance = appearance;
        }

        public void Initialize()
        {
            _appearance.TimePassed += Enable;
            _clickingParasite.ClicksCompleted += Disable;
        }

        private void Enable()
            => SetActive(true);

        private void Disable()
            => SetActive(false);

        private void SetActive(bool value)
            => _parasiteView.RectTransformObject.gameObject.SetActive(value);

        public void Dispose()
        {
            _appearance.TimePassed -= Enable;
            _clickingParasite.ClicksCompleted -= Disable;
        }
    }
}
