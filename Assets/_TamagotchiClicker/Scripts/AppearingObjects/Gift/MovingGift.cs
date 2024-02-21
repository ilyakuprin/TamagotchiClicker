using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using Zenject;

namespace TamagotchiClicker
{
    public class MovingGift : IInitializable, IDisposable
    {
        private readonly GettingStartPosition _gettingStartPosition;
        private readonly GettingEndPosition _gettingEndPosition;
        private readonly Appearance _appearance;
        private readonly MovementGift _movementGift;
        private readonly GiftConfig _config;

        private float _speed;
        private CancellationToken _ct;

        public MovingGift(GettingStartPosition gettingStartPosition,
                          GettingEndPosition gettingEndPosition,
                          MovementGift movementGift,
                          AppearanceGift appearance,
                          GiftConfig config)
        {
            _gettingStartPosition = gettingStartPosition;
            _gettingEndPosition = gettingEndPosition;
            _movementGift = movementGift;
            _appearance = appearance;
            _config = config;
        }

        public void Initialize()
        {
            _ct = _movementGift.GetCancellationTokenOnDestroy();
            _speed = 1 / _config.MoveTime;
            _appearance.TimePassed += StartMove;
        } 

        private void StartMove()
        {
            SetStartPosition();
            SetEndPosition();
            Move().Forget();
        }

        private void SetStartPosition()
            => _movementGift.SetStartPosition(_gettingStartPosition.Get());

        private void SetEndPosition()
            => _movementGift.SetEndPosition(_gettingEndPosition.Get());

        private async UniTask Move()
        {
            float time = 0;

            while (time < 1)
            {
                if (!_ct.IsCancellationRequested)
                {
                    _movementGift.ChangePosition(time);
                    time += Time.deltaTime * _speed;

                    await UniTask.NextFrame();
                }
                else
                {
                    break;
                }
            }
        }

        public void Dispose()
            => _appearance.TimePassed -= StartMove;
    }
}
