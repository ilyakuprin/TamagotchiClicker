using System;
using UnityEngine;
using Zenject;

namespace TamagotchiClicker
{
    public class ActivatingClicking : IInitializable, IDisposable
    { 
        private readonly HeroView _heroView;
        private readonly CreatingClicking _creatingClicking;
        private int _currentClick = 0;

        public ActivatingClicking(HeroView heroView,
                                  CreatingClicking creatingClicking)
        {
            _heroView = heroView;
            _creatingClicking = creatingClicking;
        }

        private void Activate()
        {
            if (_currentClick >= _creatingClicking.GetNumberClicks)
                _currentClick = 0;

            ClickBehavior clickMovement = _creatingClicking.GetClicking(_currentClick);

            if (!clickMovement.gameObject.activeInHierarchy)
            {
                clickMovement.transform.position = Input.mousePosition;
                clickMovement.gameObject.SetActive(true);
                _currentClick++;
            }
        }

        public void Initialize()
        {
            _heroView.Pressed += Activate;
        }

        public void Dispose()
        {
            _heroView.Pressed -= Activate;
        }
    }
}
