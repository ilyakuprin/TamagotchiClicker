using TamagotchiClicker;
using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

public class AddingMoney : MonoBehaviour
{
    [SerializeField] private Button _button;
    [Inject] private Saving _saving;
    [Inject] private  CostHeroesConfig _config;

    private void SetMax()
    {
        var nextHeroCost = _config.Get(YandexGame.savesData.NextHeroIndex);
        YandexGame.savesData.Money = nextHeroCost;
        _saving.Save();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(SetMax);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SetMax);
    }
}
