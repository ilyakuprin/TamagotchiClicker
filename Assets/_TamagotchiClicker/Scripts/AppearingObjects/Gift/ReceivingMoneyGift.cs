using System;
using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class ReceivingMoneyGift : IInitializable, IDisposable
    {
        private readonly GiftView _giftView;
        private readonly GiftConfig _giftConfig;
        private readonly ClickingHero _clickingHero;

        public ReceivingMoneyGift(GiftView giftView,
                                  GiftConfig giftConfig,
                                  ClickingHero clickingHero)
        {
            _giftView = giftView;
            _giftConfig = giftConfig;
            _clickingHero = clickingHero;
        }

        public void Initialize()
            => _giftView.Pressed += AddMoney;

        private void AddMoney()
        {
            var value = (ulong)Math.Ceiling(YandexGame.savesData.Money * _giftConfig.RewardMultiplier);
            _clickingHero.AddMoney(value);
        } 

        public void Dispose()
            => _giftView.Pressed -= AddMoney;
    }
}
