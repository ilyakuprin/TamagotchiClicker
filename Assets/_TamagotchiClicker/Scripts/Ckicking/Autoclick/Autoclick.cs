using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace TamagotchiClicker
{
    public class Autoclick : IInitializable
    {
        private const float TimeSec = 1f;
        private float _stopwatch;

        private readonly ClickingHero _clickingHero;

        public Autoclick(ClickingHero clickingHero)
        {
            _clickingHero = clickingHero;
        }

        public void Initialize()
            => StartTimer();

        private void StartTimer()
            => Timer().Forget();

        private async UniTask Timer()
        {
            _stopwatch = 0;

            while (_stopwatch < TimeSec)
            {
                await UniTask.NextFrame();
                _stopwatch += Time.deltaTime;
            }

            Add();
            StartTimer();
        }

        private void Add()
            => _clickingHero.OnAddMoney();
    }
}
