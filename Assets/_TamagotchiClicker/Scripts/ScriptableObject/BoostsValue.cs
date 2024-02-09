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

    [CreateAssetMenu(fileName = "BoostsValue", menuName = "Configs/BoostsValue")]
    public class BoostsValue : ScriptableObject
    {
        [SerializeField] private BoostValues[] _boosts;
    }
}
