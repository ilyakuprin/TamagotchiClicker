using System;
using Zenject;

namespace TamagotchiClicker
{
    public class ResettingClickBoost : IInitializable, IDisposable
    {
        private readonly DevastationFilling _devastationFilling;
        private readonly CalculationClick _calculationClick;
        private readonly FillingClick _fillingClick;

        public ResettingClickBoost(DevastationFilling devastationFilling,
                                   CalculationClick calculationClick,
                                   FillingClick fillingClick)
        {
            _devastationFilling = devastationFilling;
            _calculationClick = calculationClick;
            _fillingClick = fillingClick;
        }

        public void Initialize()
        {
            _devastationFilling.Devastated += Reset;
        }

        private void Reset()
        {
            if (_fillingClick.Filling.fillAmount < FillingClickConfig.MinValueForBoost)
            {
                _calculationClick.ResetFactor();
            }
        }

        public void Dispose()
        {
            _devastationFilling.Devastated -= Reset;
        }
    }
}
