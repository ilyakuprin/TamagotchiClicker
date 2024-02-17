using System;
using UnityEngine;
using Zenject;

namespace TamagotchiClicker
{
    [RequireComponent(typeof(Click))]
    public class SettingClickValue : MonoBehaviour
    {
        private const string TextFormat = "+{0}";

        [SerializeField] private Click _click;
        private CalculationClick _calculationClick;

        [Inject]
        private void Construct(CalculationClick calculationClick)
            => _calculationClick = calculationClick;

        private void OnEnable()
        {
            _click.TextValue.text = 
                String.Format(TextFormat, NumberFormat.GetFormattedString(_calculationClick.Calculate()));
        }

        private void OnValidate()
            => _click ??= GetComponent<Click>();
    }
}
