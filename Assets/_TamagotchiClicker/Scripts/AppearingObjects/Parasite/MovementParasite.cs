using System;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace TamagotchiClicker
{
    public class MovementParasite : MonoBehaviour 
    {
        public event Action MovementOver;

        [SerializeField] private RectTransform _parasite;

        private GettingStartPosition _gettingStartPosition;
        private HeroButtonView _hero;
        private ParasiteConfig _parasiteConfig;
        private AppearanceParasite _appearanceParasite;

        [Inject]
        private void Construct(GettingStartPosition gettingStartPosition,
                               HeroButtonView hero,
                               ParasiteConfig parasiteConfig,
                               AppearanceParasite appearanceParasite)
        {
            _gettingStartPosition = gettingStartPosition;
            _hero = hero;
            _parasiteConfig = parasiteConfig;
            _appearanceParasite = appearanceParasite;
        }

        private void StartMove()
        {
            SetStartPosition();
            Move();
        }

        private void SetStartPosition()
            => _parasite.anchoredPosition = _gettingStartPosition.Get();

        private void Move()
        {
            _parasite.DOMove(_hero.RectTransformHero.position,
                             _parasiteConfig.MoveTime)
                .SetEase(Ease.Linear)
                .OnKill(InvokeEvent);
        }

        //Надо ли ??
        private void InvokeEvent()
        {
            MovementOver?.Invoke();
        }

        private void OnEnable()
            => _appearanceParasite.TimePassed += StartMove;

        private void OnDisable()
            => _appearanceParasite.TimePassed -= StartMove;
    }
}
