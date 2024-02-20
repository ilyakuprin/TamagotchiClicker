using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using YG;

namespace TamagotchiClicker
{
    public class ParasiteActivity : IDisposable
    {
        private const float TimeWaiting = 1f;

        private readonly ParasiteConfig _parasiteConfig;
        private readonly Saving _saving;
        private readonly ClickingParasite _clickingParasite;

        private ulong _subtractInSec;
        private ulong _startValue;
        private CancellationTokenSource _cts;

        public ParasiteActivity(ParasiteConfig parasiteConfig,
                                Saving saving,
                                ClickingParasite clickingParasite)
        {
            _parasiteConfig = parasiteConfig;
            _saving = saving;
            _clickingParasite = clickingParasite;
        }

        public void StartActivity()
        {
            _cts = new CancellationTokenSource();
            _startValue = YandexGame.savesData.Money;
            CalculateSubtraction();
            TimerSubtract().Forget();
        }

        private void CalculateSubtraction()
        {
            var inSec = YandexGame.savesData.Money * 
                              _parasiteConfig.MultiplierCoinSubtraction /
                              _parasiteConfig.MaxSubtractionTimeSec;

            _subtractInSec = Convert.ToUInt64(Math.Ceiling(inSec));
        }

        private async UniTask TimerSubtract()
        {
            for (int i = 0; i < _parasiteConfig.MaxSubtractionTimeSec; i++)
            {
                await UniTask.WaitForSeconds(TimeWaiting);

                if (!_cts.IsCancellationRequested)
                {
                    Subtract();
                }
                else
                {
                    Add();
                    return;
                }
            }

            _clickingParasite.DriveAwayParasite();
        }

        private void Subtract()
        {
            if (YandexGame.savesData.Money > _subtractInSec)
            {
                YandexGame.savesData.Money -= _subtractInSec;
                _saving.Save();
            }
            else if (YandexGame.savesData.Money != 0u)
            {
                YandexGame.savesData.Money = 0u;
                _saving.Save();
            }
        }

        private void Add()
        {
            YandexGame.savesData.Money = _startValue;
            _saving.Save();
        }

        public void StopActivity()
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
                _cts.Dispose();
            }
        }

        public void Dispose()
        {
            StopActivity();
        }
    }
}
