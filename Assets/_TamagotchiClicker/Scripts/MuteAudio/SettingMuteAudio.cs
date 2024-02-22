using UnityEngine;
using UnityEngine.Audio;
using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class SettingMuteAudio : MonoBehaviour
    {
        private const float MuteValue = -80f;
        private const float UnmuteValue = 0f;
        private const string ParameterMusic = "Master";

        [SerializeField] private AudioMixer _audioMixer;

        private Saving _saving;

        [Inject]
        private void Construct(Saving saving)
        {
            _saving = saving;
        }

        private void Start()
            => SetSaveValue();

        public void PressIconSound()
        {
            SaveValue();
            SetSaveValue();
        }

        private void SetSaveValue()
        {
            if (YandexGame.savesData.Mute)
            {
                SetValue(MuteValue);
            }
            else
            {
                SetValue(UnmuteValue);
            }
        }

        private void SaveValue()
        {
            YandexGame.savesData.Mute = !YandexGame.savesData.Mute;
            _saving.Save();
        }

        private void SetValue(float value)
            => _audioMixer.SetFloat(ParameterMusic, value);
    }
}
