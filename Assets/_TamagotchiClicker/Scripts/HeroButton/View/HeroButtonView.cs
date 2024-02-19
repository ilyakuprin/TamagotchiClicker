using System;
using UnityEngine;
using UnityEngine.UI;

namespace TamagotchiClicker
{
    public class HeroButtonView : MonoBehaviour
    {
        public event Action Pressed;

        [SerializeField] private Button _hero;
        [field: SerializeField] public Image ImageHero { get; private set; }
        [field: SerializeField] public RectTransform RectTransformHero { get; private set; }

        private void Press()
            => Pressed?.Invoke();

        private void OnEnable()
            => _hero.onClick.AddListener(() => Press());

        private void OnDisable()
            => _hero.onClick.RemoveListener(() => Press());
    }
}
