using System;
using UnityEngine;
using UnityEngine.UI;

namespace TamagotchiClicker
{
    public class ParasiteView : MonoBehaviour
    {
        public event Action Pressed;

        [SerializeField] private Button _button;
        [field: SerializeField] public RectTransform RectTransformParasite { get; private set; }

        private void Press()
            => Pressed?.Invoke();

        private void OnEnable()
            => _button.onClick.AddListener(Press);

        private void OnDisable()
            => _button.onClick.RemoveListener(Press);
    }
}
