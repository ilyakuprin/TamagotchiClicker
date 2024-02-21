using System;
using Zenject;

namespace TamagotchiClicker
{
    public class SettingActivationGift : IInitializable, IDisposable
    {
        private readonly GiftView _giftView;
        private readonly Appearance _appearance;

        public SettingActivationGift(GiftView giftView,
                                     AppearanceGift appearanceGift)
        {
            _giftView = giftView;
            _appearance = appearanceGift;
        }

        public bool GetActive { get => _giftView.RectTransformObject.gameObject.activeInHierarchy; }

        public void Initialize()
        {
            _appearance.TimePassed += Enable;
            _giftView.Pressed += Disable;
        }

        private void Enable()
            => SetActive(true);

        private void Disable()
            => SetActive(false);

        private void SetActive(bool value)
            => _giftView.RectTransformObject.gameObject.SetActive(value);

        public void Dispose()
        {
            _appearance.TimePassed -= Enable;
            _giftView.Pressed -= Disable;
        }
    }
}
