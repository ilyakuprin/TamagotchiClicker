using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace TamagotchiClicker
{
    public class ClickViewUi : MonoBehaviour
    {
        public event Action Changed;

        [field: SerializeField] public TextMeshProUGUI Click { get; private set; }
        private Saving _saving;
        private CalculationClick _calculationClick;

        [Inject]
        private void Construct(Saving saving,
                               CalculationClick calculationClick)
        {
            _saving = saving;
            _calculationClick = calculationClick;
        }

        private void ChangeView()
        {
            var number = NumberFormat.GetFormattedString(_calculationClick.Calculate());

            if (number != Click.text)
            {
                Click.text = number;

                Changed?.Invoke();
            }
        }

        private void OnEnable()
        {
            _saving.SaveDataReceived += ChangeView;
            _calculationClick.Changed += ChangeView;
        }

        private void OnDisable()
        {
            _saving.SaveDataReceived -= ChangeView;
            _calculationClick.Changed -= ChangeView;
        }
    }
}
