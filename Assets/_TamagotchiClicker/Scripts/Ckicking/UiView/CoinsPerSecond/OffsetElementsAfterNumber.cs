using UnityEngine;
using Zenject;

namespace TamagotchiClicker
{
    public class OffsetElementsAfterNumber : MonoBehaviour
    {
        private const float NumberWidth = 15f;
        private const int MaxCharacters = 8;

        [SerializeField] private RectTransform _elements;
        private ClickViewUi _text;
        private float _startPositionX;

        [Inject]
        private void Construct(ClickViewUi text)
        {
            _text = text;
        }

        private void Awake()
        {
            _startPositionX = _elements.anchoredPosition.x;
        }

        private void Displace()
        {
            var countCharacters = _text.Click.text.Length;

            if (countCharacters > MaxCharacters)
                countCharacters = MaxCharacters;

            var offset = NumberWidth * countCharacters;
            _elements.anchoredPosition = new Vector2(_startPositionX + offset, _elements.anchoredPosition.y);
        }

        private void OnEnable()
        {
            _text.Changed += Displace;
        }

        private void OnDisable()
        {
            _text.Changed -= Displace;
        }
    }
}
