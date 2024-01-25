using DG.Tweening;
using TMPro;

namespace TamagotchiClicker
{
    public class FadeText : IFadeOut
    {
        private readonly TextMeshProUGUI _text;
        private readonly float _startAlpha = 1;

        public FadeText(TextMeshProUGUI text)
            => _text = text;

        public void FadeOut(float resultingTransparency, float timeFading)
        {
            _text.DOFade(resultingTransparency, timeFading).From(_startAlpha);
        }
    }
}
