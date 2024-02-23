using System;
using TMPro;
using UnityEngine;

namespace TamagotchiClicker
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LanguageText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        [SerializeField] private string[] _textInLanguages = new string[Enum.GetNames(typeof(Language)).Length];

        public void Set(int indexEnum)
            => _textMeshPro.text = _textInLanguages[indexEnum];

        private void OnValidate()
        {
            GetTextMeshPro();
            SetLengthArray();
        }

        private void GetTextMeshPro()
            => _textMeshPro ??= GetComponent<TextMeshProUGUI>();

        private void SetLengthArray()
        {
            var length = Enum.GetNames(typeof(Language)).Length;

            if (_textInLanguages.Length != length)
            {
                _textInLanguages = new string[length];
            }
        }
    }
}
