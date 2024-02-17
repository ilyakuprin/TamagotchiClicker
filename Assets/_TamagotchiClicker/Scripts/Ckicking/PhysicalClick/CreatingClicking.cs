using System;
using UnityEngine;
using Zenject;

namespace TamagotchiClicker
{
    public class CreatingClicking : IInitializable
    {
        private const int NumberClicks = 15;

        private readonly DiContainer _diContainer;
        private readonly Click _click;
        private readonly ParentCreatedClicks _parent;

        private ClickBehavior[] _clickings;

        public CreatingClicking(DiContainer diContainer,
                                Click click,
                                ParentCreatedClicks parent)
        {
            _diContainer = diContainer;
            _click = click;
            _parent = parent;
        }

        public int GetNumberClicks => NumberClicks;

        public ClickBehavior GetClicking(int index)
        {
            if (index >= 0 && index < NumberClicks)
                return _clickings[index];
            else
                throw new IndexOutOfRangeException();
        }

        public void Initialize()
        {
            _clickings = new ClickBehavior[NumberClicks];

            for (int i = 0; i < NumberClicks; i++)
            {
                _clickings[i] = GetCreatingClicking();
            }
        }

        private ClickBehavior GetCreatingClicking()
        {
            ClickBehavior clickMovement = _diContainer.InstantiatePrefabForComponent<ClickBehavior>(_click, _parent.Parent);

            Vector3 mousePos = Input.mousePosition;
            clickMovement.transform.position = mousePos;

            return clickMovement;
        }
    }
}
