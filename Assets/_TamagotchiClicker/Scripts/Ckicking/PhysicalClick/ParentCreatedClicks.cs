using UnityEngine;

namespace TamagotchiClicker
{
    public class ParentCreatedClicks : MonoBehaviour
    {
        [field: SerializeField] public Transform Parent { get; private set; }
    }
}
