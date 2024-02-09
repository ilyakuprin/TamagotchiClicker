using UnityEngine;
using UnityEngine.UI;

namespace TamagotchiClicker
{
    public class ShopChangeButton : MonoBehaviour
    {
        [SerializeField] private Button _heroesButton;
        [SerializeField] private Button _boostsButton;
        [SerializeField] private GameObject _shopHeroes;
        [SerializeField] private GameObject _shopBoosts;

        private void OpenHeroes(bool value)
        {
            _shopHeroes.SetActive(value);
            _shopBoosts.SetActive(!value);
        }

        private void OnEnable()
        {
            _heroesButton.onClick.AddListener(() => OpenHeroes(true));
            _boostsButton.onClick.AddListener(() => OpenHeroes(false));
        }

        private void OnDisable()
        {
            _heroesButton.onClick.RemoveListener(() => OpenHeroes(true));
            _boostsButton.onClick.RemoveListener(() => OpenHeroes(false));
        }
    }
}
