using System;
using Zenject;

namespace TamagotchiClicker
{
    public class BoostingClickForClick : IInitializable, IDisposable
    {
        private readonly CalculationClick _calculationClick;
        private readonly FillingClick _fillingClick;
        private readonly FillingClickConfig _config;

        public BoostingClickForClick(CalculationClick calculationClick,
                                     FillingClick fillingClick,
                                     FillingClickConfig config)
        {
            _calculationClick = calculationClick;
            _fillingClick = fillingClick;
            _config = config;
        }

        public void Initialize()
        {
            _fillingClick.Filled += Boost;
        }

        public void Boost()
        {
            if (_fillingClick.Filling.fillAmount > FillingClickConfig.MinValueForBoost)
            {
                _calculationClick.SetFactor(_config.BoostFactor);
            }
        }

        public void Dispose()
        {
            _fillingClick.Filled -= Boost;
        }
    }
}
