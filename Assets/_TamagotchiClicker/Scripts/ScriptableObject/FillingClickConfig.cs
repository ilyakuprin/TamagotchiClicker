using UnityEngine;

namespace TamagotchiClicker
{
    [CreateAssetMenu(fileName = "FillingClickConfig", menuName = "Configs/FillingClickConfig")]
    public class FillingClickConfig : ScriptableObject
    {
        public const float MinValueForBoost = 0.748f;

        [field: SerializeField, Range(0, 1)] public float OneClickFilling { get; private set; }
        [field: SerializeField, Range(0, 10)] public float TimeDevastationInSec { get; private set; }
        [field: SerializeField, Range(0, 10)] public float BoostFactor { get; private set; }
    }
}
