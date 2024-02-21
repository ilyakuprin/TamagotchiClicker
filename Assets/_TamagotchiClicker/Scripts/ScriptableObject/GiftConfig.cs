using UnityEngine;

namespace TamagotchiClicker
{
    [CreateAssetMenu(fileName = "GiftConfig", menuName = "Configs/GiftConfig")]
    public class GiftConfig : ScriptableObject, IMovingObject
    {
        [field: SerializeField, Range(0.1f, 10f)] public float MoveTime { get; private set; }
        [field: SerializeField, Range(0f, 1f)] public float RewardMultiplier { get; private set; }

        [SerializeField, Range(1f, 300f)] private float _occurrenceFrequencyInSec;

        public float GetOccurrenceFrequencyInSec { get => _occurrenceFrequencyInSec; }
    }
}
