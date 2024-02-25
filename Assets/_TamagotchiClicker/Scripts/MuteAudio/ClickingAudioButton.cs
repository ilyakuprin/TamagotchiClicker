using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class ClickingAudioButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _stick;

        private SettingMuteAudio _settingMuteAudio;

        [Inject]
        private void Construct(SettingMuteAudio settingMuteAudio)
        {
            _settingMuteAudio = settingMuteAudio;
        }

        private void Awake()
        {
            SetEnabledStick(YandexGame.savesData.Mute);
        }

        private void ChangeEnabledStick()
        {
            SetEnabledStick(!_stick.enabled);
        }

        private void SetEnabledStick(bool value)
            => _stick.enabled = value;

        private void OnEnable()
        {
            _button.onClick.AddListener(_settingMuteAudio.PressIconSound);
            _button.onClick.AddListener(ChangeEnabledStick);
        } 

        private void OnDisable()
        {
            _button.onClick.RemoveListener(_settingMuteAudio.PressIconSound);
            _button.onClick.RemoveListener(ChangeEnabledStick);
        } 
    }
}
