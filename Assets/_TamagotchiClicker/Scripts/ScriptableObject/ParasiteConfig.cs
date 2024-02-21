using UnityEngine;

namespace TamagotchiClicker
{
    [CreateAssetMenu(fileName = "ParasiteConfig", menuName = "Configs/ParasiteConfig")]
    public class ParasiteConfig : ScriptableObject, IMovingObject
    {
        [field: SerializeField, Range(1, 30)] public int NumberClicks { get; private set; }
        [field: SerializeField, Range(0.1f, 10f)] public float MoveTime { get; private set; }
        [field: SerializeField, Range(0f, 1f)] public float MultiplierCoinSubtraction { get; private set; }
        [field: SerializeField, Range(1f, 90f)] public float MaxSubtractionTimeSec { get; private set; }

        [SerializeField, Range(1f, 300f)] private float _occurrenceFrequencyInSec;

        public float GetOccurrenceFrequencyInSec { get => _occurrenceFrequencyInSec; }
    }
}
