using UnityEngine;

namespace TamagotchiClicker
{
    [CreateAssetMenu(fileName = "CostHeroesConfig", menuName = "Configs/CostHeroesConfig")]
    public class CostHeroesConfig : ScriptableObject
    {
        [SerializeField] private ulong[] _cost;

        public int GetLength()
            => _cost.Length;

        public ulong Get(int index)
            => _cost[index];
    }
}
