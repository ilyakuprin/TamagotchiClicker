using UnityEngine;
using UnityEngine.UI;
using YG;

namespace TamagotchiClicker
{
    public class ShowingAdsButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Show()
            => YandexGame.RewVideoShow(0);

        private void OnEnable()
            => _button.onClick.AddListener(Show);

        private void OnDisable()
            => _button.onClick.RemoveListener(Show);
    }
}
