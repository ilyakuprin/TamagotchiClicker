using DG.Tweening;
using TMPro;

namespace TamagotchiClicker
{
    public class FadeText : Fade
    {
        private readonly TextMeshProUGUI _text;

        public FadeText(float resultingTransparency, float timeFading, TextMeshProUGUI text) :
            base(resultingTransparency, timeFading)
        {
            _text = text;
        }

        public override void FadeOut()
        {
            _text.DOFade(resultingTransparency, timeFading);
            UnityEngine.Debug.Log("FadeOut FadeText");
        }
    }
}
