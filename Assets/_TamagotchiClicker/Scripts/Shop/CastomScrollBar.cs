using UnityEngine;
using UnityEngine.UI;

namespace TamagotchiClicker
{
    public class CastomScrollBar : MonoBehaviour
    {
        [SerializeField] private RectTransform _content;
        [SerializeField] private Scrollbar _scrollbar;
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField, Min(0.1f)] private float _maxValueY;

        private void OnSwipeContent(Vector2 _)
            => _scrollbar.value = _content.localPosition.y / _maxValueY;

        private void OnScrollContent(float _)
            => _content.localPosition = new Vector2(_content.localPosition.x, _scrollbar.value * _maxValueY);

        private void OnEnable()
        {
            _scrollbar.onValueChanged.AddListener(OnScrollContent);
            _scrollRect.onValueChanged.AddListener(OnSwipeContent);
        }

        private void OnDisable()
        {
            _scrollbar.onValueChanged.RemoveListener(OnScrollContent);
            _scrollRect.onValueChanged.RemoveListener(OnSwipeContent);
        }
    }
}
