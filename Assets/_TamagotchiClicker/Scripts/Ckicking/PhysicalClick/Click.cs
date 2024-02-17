using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TamagotchiClicker
{
    public class Click : MonoBehaviour
    {
        [field: SerializeField] public Image ImageIcon;
        [field: SerializeField] public TextMeshProUGUI TextValue;

        public FadeConfig FadeConfig { get; private set; }

        [Inject]
        private void Construct(FadeConfig fadeConfig)
        {
            FadeConfig = fadeConfig;
        }
    }
}
