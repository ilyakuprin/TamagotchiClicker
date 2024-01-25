using DG.Tweening;
using UnityEngine;

namespace TamagotchiClicker
{
    public class ClickMovement
    {
        private readonly RectTransform _rectTransform;

        public ClickMovement(RectTransform rectTransform)
            => _rectTransform = rectTransform;

        public void Move(float time, float takeoffAltitude)
            => DOTween.Sequence()
                .Append(_rectTransform.DOAnchorPosY(_rectTransform.localPosition.y + takeoffAltitude, time))
                .AppendCallback(Enabled);

        private void Enabled()
            => _rectTransform.gameObject.SetActive(false);
    }
}
