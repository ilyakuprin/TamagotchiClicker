using DG.Tweening;
using UnityEngine.UI;

namespace TamagotchiClicker
{
    public class FadeImage : IFadeOut
    {
        private readonly Image _image;
        private readonly float _startAlpha = 1;

        public FadeImage(Image image)
            => _image = image;

        public void FadeOut(float resultingTransparency, float timeFading)
            => _image.DOFade(resultingTransparency, timeFading).From(_startAlpha);
    }
}
