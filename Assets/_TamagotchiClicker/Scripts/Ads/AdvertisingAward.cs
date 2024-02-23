using System;
using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class AdvertisingAward : IInitializable, IDisposable
    {
        private readonly DevastationFilling _devastationFilling;
        private readonly FillingClick _fillingClick;
        private readonly AdvertisingAwardConfig _config;

        public AdvertisingAward(DevastationFilling devastationFilling,
                                FillingClick fillingClick,
                                AdvertisingAwardConfig config)
        {
            _devastationFilling = devastationFilling;
            _fillingClick = fillingClick;
            _config = config;
        }

        public void Initialize()
        {
            YandexGame.RewardVideoEvent += GetReward;
        }

        private void GetReward(int _)
        {
            _devastationFilling.StopDevastate(_config.MultiplierTime);
            _fillingClick.FullFill();
        }

        public void Dispose()
        {
            YandexGame.RewardVideoEvent -= GetReward;
        }
    }
}
