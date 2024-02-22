using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TamagotchiClicker
{
    public class ClickingAudioButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private SettingMuteAudio _settingMuteAudio;

        [Inject]
        private void Construct(SettingMuteAudio settingMuteAudio)
        {
            _settingMuteAudio = settingMuteAudio;
        }

        private void OnEnable()
            => _button.onClick.AddListener(_settingMuteAudio.PressIconSound);

        private void OnDisable()
            => _button.onClick.RemoveListener(_settingMuteAudio.PressIconSound);
    }
}
