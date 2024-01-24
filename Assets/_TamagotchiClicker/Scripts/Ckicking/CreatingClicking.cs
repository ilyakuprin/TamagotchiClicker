using System;
using UnityEngine;
using Zenject;

namespace TamagotchiClicker
{
    public class CreatingClicking : IInitializable, IDisposable
    {
        private readonly DiContainer _diContainer;
        private readonly Clicking _clicking;
        private readonly ParentCreatedClicks _parent;
        private readonly HeroButtonView _heroButtonView;

        public CreatingClicking(DiContainer diContainer,
                                Clicking clicking,
                                ParentCreatedClicks parent,
                                HeroButtonView heroButtonView)
        {
            _diContainer = diContainer;
            _clicking = clicking;
            _parent = parent;
            _heroButtonView = heroButtonView;
        }

        private void OnCreate()
        {
            Clicking clicking = _diContainer.InstantiatePrefabForComponent<Clicking>(_clicking, _parent.Parent);

            Vector3 mousePos = Input.mousePosition;
            clicking.transform.position = mousePos;
        }

        public void Initialize()
            => _heroButtonView.Pressed += OnCreate;

        public void Dispose()
            => _heroButtonView.Pressed -= OnCreate;
    }
}
