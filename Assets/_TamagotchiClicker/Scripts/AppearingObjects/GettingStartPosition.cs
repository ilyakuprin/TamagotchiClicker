using System;
using UnityEngine;

namespace TamagotchiClicker
{
    public class GettingStartPosition : GettingRandomPosition
    {
        private void Awake()
            => SetArray(new Func<Vector2>[] { GetBottom, GetLeft, GetUp });
    }
}
