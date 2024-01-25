using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TamagotchiClicker
{
    public class Clicking : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _text;

        private FadeConfig _fadeConfig;
        private IFadeOut[] _fade;
        private ClickMovement _clickMovement;

        [Inject]
        private void Construct(FadeConfig fadeConfig)
        {
            _fadeConfig = fadeConfig;
        }

        private void Awake()
        {
            _fade = new IFadeOut[] { new FadeText(_text), new FadeImage(_image) };
            _clickMovement = new ClickMovement((RectTransform)transform);
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            foreach (IFadeOut fade in _fade)
                fade.FadeOut(_fadeConfig.ResultingTransparency, _fadeConfig.TimeFading);

            _clickMovement.Move(_fadeConfig.TimeFading, _fadeConfig.TakeoffAltitude);
        }
    }
}
