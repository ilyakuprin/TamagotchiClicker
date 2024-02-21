using System;
using UnityEngine;
using UnityEngine.UI;

namespace TamagotchiClicker
{
    public class AppearingObjectsView : MonoBehaviour
    {
        public event Action Pressed;

        [field: SerializeField] public RectTransform RectTransformObject { get; private set; }

        [SerializeField] private Button _button;

        private void Press()
            => Pressed?.Invoke();

        private void OnEnable()
            => _button.onClick.AddListener(Press);

        private void OnDisable()
            => _button.onClick.RemoveListener(Press);
    }
}
