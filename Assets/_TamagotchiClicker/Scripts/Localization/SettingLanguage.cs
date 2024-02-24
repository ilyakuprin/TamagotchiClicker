using UnityEngine;
using YG;

namespace TamagotchiClicker
{
    public enum Language
    {
        Ru = 0,
        Eu = 1
    }

    public class SettingLanguage : MonoBehaviour
    {
        [SerializeField] private LanguageText[] _languageTexts;

        private void Awake()
        {
            SetLanguage(YandexGame.savesData.language);
        }

        private void SetLanguage(string lang)
        {
            switch (lang)
            {
                case "ru":
                    ChangeAllText((int)Language.Ru);
                    break;
                case "eu":
                    ChangeAllText((int)Language.Eu);
                    break;
                default:
                    ChangeAllText((int)Language.Eu);
                    break;
            }
        }

        private void ChangeAllText(int lang)
        {
            foreach (var languageText in _languageTexts)
            {
                languageText.Set(lang);
            }
        }

#if UNITY_EDITOR
        public void FindAllLanguageText()
        {
            _languageTexts = Resources.FindObjectsOfTypeAll<LanguageText>();
            Debug.Log(_languageTexts.Length + " объектов");
        }
#endif

        private void OnEnable()
            => YandexGame.SwitchLangEvent += SetLanguage;

        private void OnDisable()
            => YandexGame.SwitchLangEvent -= SetLanguage;
    }
}
