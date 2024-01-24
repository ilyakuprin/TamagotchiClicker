using System;
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

        [Inject]
        private void Construct(FadeConfig fadeConfig)
        {
            _fadeConfig = fadeConfig;
        }

        private void Start()
        {
            Fade fadeText = new FadeText(_fadeConfig.ResultingTransparency,
                                         _fadeConfig.TimeFading,
                                         _text);

            Fade fadeImage = new FadeImage(_fadeConfig.ResultingTransparency,
                                           _fadeConfig.TimeFading,
                                           _image);


            fadeText.FadeOut();
            fadeImage.FadeOut();
        }
    }
}
