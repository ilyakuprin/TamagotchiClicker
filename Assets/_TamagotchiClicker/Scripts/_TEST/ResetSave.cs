using TamagotchiClicker;
using UnityEngine;
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
        YandexGame.savesData.NextHeroIndex = 1;

        _saving.Save();
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
