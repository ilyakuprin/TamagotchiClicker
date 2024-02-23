using UnityEngine;
using UnityEngine.UI;
using YG;

namespace TamagotchiClicker
{
    public class LanguageSwitchButton : MonoBehaviour
    {
        [SerializeField] private Button _languageButton;
        [SerializeField] private Image _languageImage;
        [SerializeField] private Sprite _ru;
        [SerializeField] private Sprite _eu;

        private void Switch()
        {
            var language = YandexGame.savesData.language;

            switch (language)
            {
                case "ru":
                    YandexGame.SwitchLanguage("eu");
                    break;
                case "eu":
                    YandexGame.SwitchLanguage("ru");
                    break;
                default:
                    YandexGame.SwitchLanguage("eu");
                    break;
            }
        }

        private void ChangeButton(string language)
        {
            switch (language)
            {
                case "ru":
                    SetSprite(_ru);
                    break;
                case "eu":
                    SetSprite(_eu);
                    break;
                default:
                    SetSprite(_eu);
                    break;
            }
        }

        private void SetSprite(Sprite flag)
            => _languageImage.sprite = flag;

        private void OnEnable()
        {
            _languageButton.onClick.AddListener(Switch);

            YandexGame.SwitchLangEvent += ChangeButton;
        }

        private void OnDisable()
        {
            _languageButton.onClick.RemoveListener(Switch);

            YandexGame.SwitchLangEvent -= ChangeButton;
        }
    }
}
