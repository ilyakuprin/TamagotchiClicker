using UnityEngine;

namespace TamagotchiClicker
{
    [CreateAssetMenu(fileName = "AdvertisingAwardConfig", menuName = "Configs/AdvertisingAwardConfig")]
    public class AdvertisingAwardConfig : ScriptableObject
    {
        [field: SerializeField, Range(0f, 30f)] public float MultiplierTime { get; private set; }
    }
}
