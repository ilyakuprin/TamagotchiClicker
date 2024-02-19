using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using Zenject;

namespace TamagotchiClicker
{
    public class AppearanceParasite : IInitializable, IDisposable
    {
        public event Action TimePassed;

        private readonly ParasiteConfig _parasiteConfig;
        private CancellationTokenSource _cts;

        public AppearanceParasite(ParasiteConfig parasiteConfig)
        {
            _parasiteConfig = parasiteConfig;
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
            await UniTask.WaitForSeconds(_parasiteConfig.OccurrenceFrequencyInSec);

            if (!_cts.IsCancellationRequested)
            {
                TimePassed?.Invoke();
            }
        }

        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
        }
    }
}
