using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TamagotchiClicker
{
    public class GettingStartPosition : MonoBehaviour
    {
        [SerializeField] private RectTransform _bottomRightCorner;
        [SerializeField] private RectTransform _bottomLeftCorner;
        [SerializeField] private RectTransform _upperLeftCorner;
        [SerializeField] private RectTransform _upperRightCorner;

        private Func<Vector2>[] _methodsGettingPosition;

        private void Awake()
        {
            _methodsGettingPosition = new Func<Vector2>[] { GetBottom, GetLeft, GetUp };
        }

        public Vector2 Get()
        {
            var index = Random.Range(0, _methodsGettingPosition.Length);

            return _methodsGettingPosition[index].Invoke();
        }

        private Vector2 GetBottom()
        {
            var position = new Vector2(0, _bottomRightCorner.anchoredPosition.y);
            position.x = Random.Range(_bottomLeftCorner.anchoredPosition.x, _bottomRightCorner.anchoredPosition.x);

            return position;
        }

        private Vector2 GetLeft()
        {
            var position = new Vector2(_upperLeftCorner.anchoredPosition.x, 0);
            position.y = Random.Range(_bottomLeftCorner.anchoredPosition.y, _upperLeftCorner.anchoredPosition.y);

            return position;
        }

        private Vector2 GetUp()
        {
            var position = new Vector2(0, _upperLeftCorner.anchoredPosition.y);
            position.y = Random.Range(_upperLeftCorner.anchoredPosition.y, _upperRightCorner.anchoredPosition.y);

            return position;
        }
    }
}
