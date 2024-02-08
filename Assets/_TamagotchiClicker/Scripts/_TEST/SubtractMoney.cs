using TamagotchiClicker;
using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

public class SubtractMoney : MonoBehaviour
{
    [SerializeField] private Button _button;
    [Inject] private Saving _saving;

    private void Subtract()
    {
        if (YandexGame.savesData.Money > 0)
        {
            YandexGame.savesData.Money--;
            _saving.Save();
        }
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Subtract);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Subtract);
    }
}
