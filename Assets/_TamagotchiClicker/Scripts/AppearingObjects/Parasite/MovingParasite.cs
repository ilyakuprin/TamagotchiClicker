using DG.Tweening;
using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace TamagotchiClicker
{
    public class MovingParasite : IInitializable, IDisposable
    {
        private readonly GettingStartPosition _gettingStartPosition;
        private readonly HeroView _hero;
        private readonly ParasiteConfig _parasiteConfig;
        private readonly Appearance _appearance;
        private readonly ParasiteView _parasiteView;

        private MovingParasite(GettingStartPosition gettingStartPosition,
                               HeroView hero,
                               ParasiteConfig parasiteConfig,
                               AppearanceParasite appearance,
                               ParasiteView parasiteView)
        {
            _gettingStartPosition = gettingStartPosition;
            _hero = hero;
            _parasiteConfig = parasiteConfig;
            _appearance = appearance;
            _parasiteView = parasiteView;
        }

        public void Initialize()
            => _appearance.TimePassed += StartMove;

        private void StartMove()
        {
            SetStartPosition();
            Move();
        }

        private void SetStartPosition()
            => _parasiteView.RectTransformObject.anchoredPosition = _gettingStartPosition.Get();

        private Vector2 GetEndPosition()
        {
            var hero = _hero.RectTransformHero;

            var leftBottomCorner = hero.anchoredPosition - hero.sizeDelta / 4;
            var rightUpperCorner = hero.anchoredPosition + hero.sizeDelta / 4;

            _parasiteView.EndPoint.anchoredPosition = new Vector2(Random.Range(leftBottomCorner.x, rightUpperCorner.x),
                Random.Range(leftBottomCorner.y, rightUpperCorner.y));

            return _parasiteView.EndPoint.position;
        }

        private void Move()
        {
            _parasiteView.RectTransformObject.DOMove(GetEndPosition(),
                                                     _parasiteConfig.MoveTime)
                .SetEase(Ease.Linear);
        }

        public void Dispose()
            => _appearance.TimePassed -= StartMove;
    }
}
