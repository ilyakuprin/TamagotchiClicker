using System;
using UnityEngine;
using Zenject;

namespace TamagotchiClicker
{
    public class ActivatingClicking : IInitializable, IDisposable
    { 
        private readonly HeroButtonView _heroButtonView;
        private readonly CreatingClicking _creatingClicking;
        private int _currentClick = 0;

        public ActivatingClicking(HeroButtonView heroButtonView,
                                  CreatingClicking creatingClicking)
        {
            _heroButtonView = heroButtonView;
            _creatingClicking = creatingClicking;
        }

        private void Activate()
        {
            if (_currentClick >= _creatingClicking.NumberClicks)
                _currentClick = 0;

            Clicking clicking = _creatingClicking.GetClicking(_currentClick);

            if (!clicking.gameObject.activeInHierarchy)
            {
                clicking.transform.position = Input.mousePosition;
                clicking.gameObject.SetActive(true);
                _currentClick++;
            }
        }

        public void Initialize()
        {
            _heroButtonView.Pressed += Activate;
        }

        public void Dispose()
        {
            _heroButtonView.Pressed -= Activate;
        }
    }
}
