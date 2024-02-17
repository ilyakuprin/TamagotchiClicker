using System;
using YG;

namespace TamagotchiClicker
{
    public class CalculationClick
    {
        public event Action Changed;

        private const float StartFactor = 1f;
        private float _factor = StartFactor;

        public void SetFactor(float factor)
        {
            if (_factor != factor)
            {
                _factor = factor;
                Changed?.Invoke();
            }
        }

        public void ResetFactor()
        {
            if (_factor != StartFactor)
            {
                _factor = StartFactor;
                Changed?.Invoke();
            }
        }

        public ulong Calculate()
        {
            return YandexGame.savesData.ClickValue * Convert.ToUInt64(_factor);
        }
    }
}
