using UnityEngine;

namespace TamagotchiClicker
{
    public class ParasiteView : AppearingObjectsView
    {
        [field: SerializeField] public RectTransform EndPoint { get; private set; }
    }
}
