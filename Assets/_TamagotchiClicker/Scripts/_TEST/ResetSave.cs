using TamagotchiClicker;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;
using Zenject;

public class ResetSave : MonoBehaviour
{
    [SerializeField] private Button _button;
    [Inject] private readonly Saving _saving;

    private void Reset()
    {
        YandexGame.savesData.Money = 0;
        YandexGame.savesData.ClickValue = 1;
        YandexGame.savesData.NextHeroIndex = 1;
        YandexGame.savesData.CurrentBoostIndex = 0;
        YandexGame.savesData.NumberImprovements = new ulong[10];
        YandexGame.savesData.IndexSelectedHero = 0;
        YandexGame.savesData.Mute = false;

        _saving.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Reset);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Reset);
    }
}
