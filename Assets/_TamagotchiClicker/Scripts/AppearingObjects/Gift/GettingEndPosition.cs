using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TamagotchiClicker
{
    public class GettingEndPosition : GettingRandomPosition
    {
        private void Awake()
            => SetArray(new Func<Vector2>[] { GetBottom, GetLeft, GetUp, GetRight });

        private Vector2 GetRight()
        {
            var position = new Vector2(upperRightCorner.anchoredPosition.x, 0);
            position.y = Random.Range(bottomRightCorner.anchoredPosition.y, upperRightCorner.anchoredPosition.y);

            return position;
        }
    }
}
