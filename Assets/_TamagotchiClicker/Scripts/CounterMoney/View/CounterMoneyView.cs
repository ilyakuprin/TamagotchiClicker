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
        private int _max = 100;
        private Saving _saving;

        [Inject]
        private void Construct(Saving saving)
            => _saving = saving;

        private void Show()
            => _text.text = string.Format(FormatString, YandexGame.savesData.Money, _max);

        private void OnEnable()
            => _saving.SaveDataReceived += Show;

        private void OnDisable()
            => _saving.SaveDataReceived -= Show;
    }
}
