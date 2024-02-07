using TMPro;
using UnityEngine;
using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class CounterMoneyView : MonoBehaviour
    {
        private const string FormatString = "{0}/{1}";

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
            => _text.text = string.Format(FormatString,
                                          YandexGame.savesData.Money,
                                          _config.Get(YandexGame.savesData.NextHeroIndex));

        private void OnEnable()
            => _saving.SaveDataReceived += Show;

        private void OnDisable()
            => _saving.SaveDataReceived -= Show;
    }
}
