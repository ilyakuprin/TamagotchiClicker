using DG.Tweening;
using UnityEngine.UI;

namespace TamagotchiClicker
{
    public class FadeImage : Fade
    {
        private readonly Image _image; 

        public FadeImage(float resultingTransparency, float timeFading, Image image) :
            base(resultingTransparency, timeFading)
        {
            _image = image;
        }

        public override void FadeOut()
            => _image.DOFade(resultingTransparency, timeFading);
    }
}
