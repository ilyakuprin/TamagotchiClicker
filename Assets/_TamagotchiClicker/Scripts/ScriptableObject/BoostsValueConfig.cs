using System;
using UnityEngine;

namespace TamagotchiClicker
{
    [Serializable]
    public struct BoostValues
    {
        public ulong InitialCost;
        public ulong GainImprovement;
        public float CostSubsequentImprovements;
    }

    [CreateAssetMenu(fileName = "BoostsValueConfig", menuName = "Configs/BoostsValueConfig")]
    public class BoostsValueConfig : ScriptableObject
    {
        [SerializeField] private BoostValues[] _boosts;

        public ulong GetCost(int index)
            => _boosts[index].InitialCost;

        public ulong GetGainImprovement(int index)
            => _boosts[index].GainImprovement;

        public float GetImprovement(int index)
            => _boosts[index].CostSubsequentImprovements;
    }
}
