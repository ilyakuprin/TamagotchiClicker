using TMPro;
using UnityEngine;
using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class CounterMoneyView : MonoBehaviour
    {
        private const string FormatString = "{0}/{1}";
        private const string FormatStringAllHeroOpen = "{0}";

        [SerializeField] private TextMeshProUGUI _text;
        private Saving _saving;
        private CostHeroesConfig _config;

        [Inject]
        private void Construct(Saving saving,
                               CostHeroesConfig config)
        {
            _saving = saving;
            _config = config;
        }

        private void Show()
        {
            if (YandexGame.savesData.NextHeroIndex < _config.GetLength())
            {
                _text.text = string.Format(FormatString,
                    NumberFormat.GetFormattedString(YandexGame.savesData.Money),
                    NumberFormat.GetFormattedString(_config.Get(YandexGame.savesData.NextHeroIndex)));
            }
            else
            {
                _text.text = string.Format(FormatStringAllHeroOpen,
                    NumberFormat.GetFormattedString(YandexGame.savesData.Money));
            }
        }

        private void OnEnable()
            => _saving.SaveDataReceived += Show;

        private void OnDisable()
            => _saving.SaveDataReceived -= Show;
    }
}
