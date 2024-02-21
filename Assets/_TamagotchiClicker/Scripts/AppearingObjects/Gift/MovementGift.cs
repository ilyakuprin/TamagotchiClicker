using UnityEngine;
using Zenject;

namespace TamagotchiClicker
{
    public class MovementGift : MonoBehaviour
    {
        private const int CountPoints = 4;

        [SerializeField] private RectTransform _gift;
        [SerializeField] private RectTransform[] _points = new RectTransform[CountPoints];
        [SerializeField, Range(0f, 1f)] private float _path;

        [Inject]
        private void Construct(GiftView giftView)
        {
            _gift = giftView.RectTransformObject;
        }

        private void Awake()
            => ChangePosition(0f);

        public void SetStartPosition(Vector2 position)
            => _points[0].anchoredPosition = position;

        public void SetEndPosition(Vector2 position)
            => _points[3].anchoredPosition = position;

        public void ChangePosition(float progressOnPath)
            => _gift.transform.position = Bezier.GetPoint(_points[0].position,
                                                          _points[1].position,
                                                          _points[2].position,
                                                          _points[3].position,
                                                          progressOnPath);

        private void OnDrawGizmos()
        {
            var segmentsNumber = 20;
            var previewPoint = _points[0].position;

            for (var i = 0; i < segmentsNumber + 1; i++)
            {
                var parameter = (float)i / segmentsNumber;
                var point = Bezier.GetPoint(_points[0].position,
                                                   _points[1].position,
                                                   _points[2].position,
                                                   _points[3].position,
                                                   parameter);
                Gizmos.DrawLine(previewPoint, point);
                previewPoint = point;
            }
        }

        private void OnValidate()
        {
            ChangePosition(_path);

            if (_points.Length != CountPoints)
            {
                _points = new RectTransform[CountPoints];
            }
        }
    }
}
