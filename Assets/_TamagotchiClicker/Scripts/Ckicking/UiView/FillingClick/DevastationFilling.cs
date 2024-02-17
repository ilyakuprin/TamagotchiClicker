using System;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using Zenject;

namespace TamagotchiClicker
{
    public class DevastationFilling :IInitializable
    {
        public event Action Devastated;

        private const float MaxFill = 1f;

        private readonly FillingClickConfig _fillingClickConfig;
        private readonly FillingClick _fillingClick;

        private float _speed;
        private CancellationToken _ct;
        private bool _isStop;

        public DevastationFilling(FillingClickConfig fillingClickConfig,
                                  FillingClick fillingClick)
        {
            _fillingClickConfig = fillingClickConfig;
            _fillingClick = fillingClick;
        }

        public void Initialize()
        {
            _ct = _fillingClick.gameObject.GetCancellationTokenOnDestroy();
            _speed = MaxFill / _fillingClickConfig.TimeDevastationInSec;
            
            StartDevastate();
        }

        public void StartDevastate()
        {
            _isStop = false;
            Devastate().Forget();
        } 

        public void StopDevastate()
            => _isStop = true;

        private async UniTask Devastate()
        {
            if (!_ct.IsCancellationRequested)
            {
                _fillingClick.Filling.fillAmount -= _speed * Time.deltaTime;
                Devastated?.Invoke();

                await UniTask.NextFrame();

                if (!_isStop)
                    StartDevastate();
            }
        }
    }
}
