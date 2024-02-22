using TMPro;
using UnityEngine;
using YG;

namespace TamagotchiClicker
{
    public class ShowingNumberImprovements : MonoBehaviour
    {
        private const string FormatString = "x{0}";

        [SerializeField] private TextMeshProUGUI[] _texts;

        private void Awake()
            => Show();

        private void Show()
        {
            for (var i = 0; i < YandexGame.savesData.NumberImprovements.Length; i++)
            {
                ChangeNumber(i);
            }
        }

        public void ChangeNumber(int index)
            => _texts[index].text = GetValueString(YandexGame.savesData.NumberImprovements[index]);

        private string GetValueString(ulong value)
            => string.Format(FormatString, value);
    }
}
