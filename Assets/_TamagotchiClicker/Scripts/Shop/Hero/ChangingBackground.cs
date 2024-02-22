using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TamagotchiClicker
{
    public class ChangingBackground : MonoBehaviour
    {
        [SerializeField] private Image _background;

        private HeroMatching _heroMatching;

        [Inject]
        private void Construct(HeroMatching heroMatching)
        {
            _heroMatching = heroMatching;
        }

        private void SubscribeOnBuyButton()
        {
            for (var i = 0; i < _heroMatching.GetLength(); i++)
            {
                var hero = _heroMatching.Get(i);
                var spriteBack = hero.Background;
                hero.Buy.onClick.AddListener(() => ChangeSprite(spriteBack));
            }
        }

        private void UnsubscribeOnBuyButton()
        {
            for (var i = 0; i < _heroMatching.GetLength(); i++)
            {
                var hero = _heroMatching.Get(i);
                var spriteBack = hero.Background;
                hero.Buy.onClick.RemoveListener(() => ChangeSprite(spriteBack));
            }
        }

        public void ChangeSprite(Sprite spriteHero)
        {
            if (_background.sprite != spriteHero)
            {
                _background.sprite = spriteHero;
            }
        } 

        private void OnEnable()
            => SubscribeOnBuyButton();

        private void OnDisable()
            => UnsubscribeOnBuyButton();
    }
}
