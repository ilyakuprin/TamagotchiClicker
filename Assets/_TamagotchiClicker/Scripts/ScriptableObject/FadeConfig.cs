using UnityEngine;

namespace TamagotchiClicker
{
    [CreateAssetMenu(fileName = "FadeConfig", menuName = "Configs/FadeConfig")]
    public class FadeConfig : ScriptableObject
    {
        [field: SerializeField, Range(0, 1)] public float ResultingTransparency { get; private set; }
        [field: SerializeField, Range(0, 10)] public float TimeFading { get; private set; }
        [field: SerializeField, Range(0, 1000)] public float TakeoffAltitude { get; private set; }
    }
}
