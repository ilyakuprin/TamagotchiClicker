using DG.Tweening;
using System;
using Zenject;

namespace TamagotchiClicker
{
    public class MovementParasite : IInitializable, IDisposable
    {
        private readonly GettingStartPosition _gettingStartPosition;
        private readonly HeroView _hero;
        private readonly ParasiteConfig _parasiteConfig;
        private readonly AppearanceParasite _appearanceParasite;
        private readonly ParasiteView _parasiteView;

        private MovementParasite(GettingStartPosition gettingStartPosition,
                                 HeroView hero,
                                 ParasiteConfig parasiteConfig,
                                 AppearanceParasite appearanceParasite,
                                 ParasiteView parasiteView)
        {
            _gettingStartPosition = gettingStartPosition;
            _hero = hero;
            _parasiteConfig = parasiteConfig;
            _appearanceParasite = appearanceParasite;
            _parasiteView = parasiteView;
        }

        public void Initialize()
            => _appearanceParasite.TimePassed += StartMove;

        private void StartMove()
        {
            SetStartPosition();
            Move();
        }

        private void SetStartPosition()
            => _parasiteView.RectTransformParasite.anchoredPosition = _gettingStartPosition.Get();

        private void Move()
        {
            _parasiteView.RectTransformParasite.DOMove(_hero.RectTransformHero.position,
                                                       _parasiteConfig.MoveTime)
                .SetEase(Ease.Linear);
        }

        public void Dispose()
            => _appearanceParasite.TimePassed -= StartMove;
    }
}
