using UnityEngine;

namespace TamagotchiClicker
{
    [CreateAssetMenu(fileName = "ParasiteConfig", menuName = "Configs/ParasiteConfig")]
    public class ParasiteConfig : ScriptableObject
    {
        [field: SerializeField, Range(1, 30)] public int NumberClicks { get; private set; }
        [field: SerializeField, Range(0.1f, 10f)] public float MoveTime { get; private set; }
        [field: SerializeField, Range(1f, 300f)] public float OccurrenceFrequencyInSec { get; private set; }
    }
}
