using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace TamagotchiClicker
{
    public class Autoclick : IInitializable, IDisposable
    {
        private const float TimeSec = 1f;
        private readonly ClickingHero _clickingHero;
        private CancellationTokenSource _cts;

        public Autoclick(ClickingHero clickingHero)
        {
            _clickingHero = clickingHero;
        }

        public void Initialize()
        {
            _cts = new CancellationTokenSource();
            StartTimer();
        } 

        private void StartTimer()
            => Timer().Forget();

        private async UniTask Timer()
        {
            await UniTask.WaitForSeconds(TimeSec);
            if (!_cts.IsCancellationRequested)
            {
                Add();
                StartTimer();
            }
        }

        private void Add()
            => _clickingHero.OnAddMoney();

        public void Dispose()
        {
            if (!_cts.IsCancellationRequested)
            {
                _cts.Cancel();
                _cts.Dispose();
            }
        } 
    }
}
