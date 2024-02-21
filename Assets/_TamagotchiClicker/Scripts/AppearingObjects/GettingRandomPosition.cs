using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TamagotchiClicker
{
    public abstract class GettingRandomPosition : MonoBehaviour
    {
        [field: SerializeField] protected RectTransform bottomRightCorner { get; private set; }
        [field: SerializeField] protected RectTransform bottomLeftCorner { get; private set; }
        [field: SerializeField] protected RectTransform upperLeftCorner { get; private set; }
        [field: SerializeField] protected RectTransform upperRightCorner { get; private set; }

        private Func<Vector2>[] _methodsGettingPosition;

        protected void SetArray(Func<Vector2>[] arrayFunc)
        {
            _methodsGettingPosition = new Func<Vector2>[arrayFunc.Length];
            arrayFunc.CopyTo(_methodsGettingPosition, 0);
        }

        public Vector2 Get()
        {
            if (_methodsGettingPosition != null)
            {
                var index = Random.Range(0, _methodsGettingPosition.Length);

                return _methodsGettingPosition[index].Invoke();
            }
            else
            {
                throw new NotImplementedException("The array is not initialized");
            }
        }

        protected Vector2 GetBottom()
        {
            var position = new Vector2(0, bottomRightCorner.anchoredPosition.y);
            position.x = Random.Range(bottomLeftCorner.anchoredPosition.x, bottomRightCorner.anchoredPosition.x);

            return position;
        }

        protected Vector2 GetLeft()
        {
            var position = new Vector2(upperLeftCorner.anchoredPosition.x, 0);
            position.y = Random.Range(bottomLeftCorner.anchoredPosition.y, upperLeftCorner.anchoredPosition.y);

            return position;
        }

        protected Vector2 GetUp()
        {
            var position = new Vector2(0, upperLeftCorner.anchoredPosition.y);
            position.y = Random.Range(upperLeftCorner.anchoredPosition.y, upperRightCorner.anchoredPosition.y);

            return position;
        }
    }
}
