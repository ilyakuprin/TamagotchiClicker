using UnityEngine;

namespace TamagotchiClicker
{
    [CreateAssetMenu(fileName = "CostHeroesConfig", menuName = "Configs/CostHeroesConfig")]
    public class CostHeroesConfig : ScriptableObject
    {
        [SerializeField] private int[] _cost;

        public int[] Get()
        {
            var copyArray = new int[_cost.Length];
            _cost.CopyTo(copyArray, 0);
            return copyArray;
        }

        public int GetValue(int index)
            => _cost[index];
    }
}
