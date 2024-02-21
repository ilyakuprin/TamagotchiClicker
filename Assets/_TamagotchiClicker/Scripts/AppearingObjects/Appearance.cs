using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using Zenject;

namespace TamagotchiClicker
{
    public class Appearance : IInitializable, IDisposable
    {
        public event Action TimePassed;

        protected readonly IMovingObject _config;
        private CancellationTokenSource _cts;

        public Appearance(IMovingObject config)
        {
            _config = config;
        }

        public void Initialize()
        {
            _cts = new CancellationTokenSource();
            StartWait();
        }

        private void StartWait()
            => Wait().Forget();

        private async UniTask Wait()
        {
            await UniTask.WaitForSeconds(_config.GetOccurrenceFrequencyInSec);

            if (!_cts.IsCancellationRequested)
            {
                TimePassed?.Invoke();
            }
        }

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
