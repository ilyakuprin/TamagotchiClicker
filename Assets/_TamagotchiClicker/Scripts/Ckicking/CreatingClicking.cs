using System;
using UnityEngine;
using Zenject;

namespace TamagotchiClicker
{
    public class CreatingClicking : IInitializable
    {
        private readonly DiContainer _diContainer;
        private readonly Clicking _clicking;
        private readonly ParentCreatedClicks _parent;

        private Clicking[] _clickings;
        public readonly int _numberÑlicks = 15;

        public CreatingClicking(DiContainer diContainer,
                                Clicking clicking,
                                ParentCreatedClicks parent)
        {
            _diContainer = diContainer;
            _clicking = clicking;
            _parent = parent;
        }

        public int NumberÑlicks { get => _numberÑlicks; }

        public Clicking GetClicking(int index)
        {
            if (index >=0 && index < _numberÑlicks)
                return _clickings[index];
            else
                throw new IndexOutOfRangeException();
        }

        public void Initialize()
        {
            _clickings = new Clicking[_numberÑlicks];

            for (int i = 0; i < _numberÑlicks; i++)
            {
                _clickings[i] = GetCreatingClicking();
            }
        }

        private Clicking GetCreatingClicking()
        {
            Clicking clicking = _diContainer.InstantiatePrefabForComponent<Clicking>(_clicking, _parent.Parent);

            Vector3 mousePos = Input.mousePosition;
            clicking.transform.position = mousePos;

            return clicking;
        }
    }
}
