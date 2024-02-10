using System;
using UnityEngine;

namespace TamagotchiClicker
{
    [Serializable]
    public struct BoostValues
    {
        public ulong InitialCost;
        public uint GainImprovement;
        public float CostSubsequentImprovements;
    }

    [CreateAssetMenu(fileName = "BoostsValueConfig", menuName = "Configs/BoostsValueConfig")]
    public class BoostsValueConfig : ScriptableObject
    {
        [SerializeField] private BoostValues[] _boosts;

        public ulong GetCost(int index)
            => _boosts[index].InitialCost;

        public float GetImprovement(int index)
            => _boosts[index].CostSubsequentImprovements;
    }
}
