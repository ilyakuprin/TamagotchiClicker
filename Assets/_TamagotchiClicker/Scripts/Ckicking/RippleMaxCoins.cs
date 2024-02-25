using DG.Tweening;
using UnityEngine;
using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class RippleMaxCoins : MonoBehaviour
    {
        private const float MaxSize = 1.06f;
        private const float TimeRipple = 0.5f;
        
        [SerializeField] private RectTransform _clickView;

        private Vector3 _startScale;
        private ClickingHero _clickingHero;
        private Saving _saving;
        private bool _isRipple;

        [Inject]
        private void Construct(ClickingHero clickingHero,
                               Saving saving)
        {
            _clickingHero = clickingHero;
            _saving = saving;
        }

        private void Awake()
        {
            _startScale = _clickView.lossyScale;
        }

        private void StartRipple()
        {
            if (_clickingHero.IsMoreMax())
            {
                _isRipple = true;
                RippleUp();
            }
            else if (_isRipple)
            {
                _isRipple = false;
            }
        }

        private void RippleUp()
        {
            if (_isRipple)
            {
                _clickView.DOScale(Vector3.one * MaxSize, TimeRipple)
                    .SetEase(Ease.Linear)
                    .OnKill(RippleDown);
            }
        }

        private void RippleDown()
        {
            _clickView.DOScale(_startScale, TimeRipple)
                .SetEase(Ease.Linear)
                .OnKill(RippleUp);
        }

        private void OnEnable()
        {
            _saving.SaveDataReceived += StartRipple;
        }

        private void OnDisable()
        {
            _saving.SaveDataReceived -= StartRipple;
        }
    }
}
