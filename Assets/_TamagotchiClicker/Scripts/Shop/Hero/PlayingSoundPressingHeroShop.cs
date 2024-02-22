using Zenject;

namespace TamagotchiClicker
{
    public class PlayingSoundPressingHeroShop : PlayingSoundWhenPressed
    {
        private HeroMatching _heroMatching;

        [Inject]
        private void Constructor(HeroMatching heroMatching)
        {
            _heroMatching = heroMatching;
        }

        private void SubscribeToButtons()
        {
            for (int i = 0; i < _heroMatching.GetLength(); i++)
            {
                var index = i;
                var button = _heroMatching.Get(index);
                button.Buy.onClick.AddListener(Play);
            }
        }

        private void UnsubscribeToButtons()
        {
            for (int i = 0; i < _heroMatching.GetLength(); i++)
            {
                var index = i;
                var button = _heroMatching.Get(index);
                button.Buy.onClick.RemoveListener(Play);
            }
        }

        private void OnEnable()
            => SubscribeToButtons();

        private void OnDisable()
            => UnsubscribeToButtons();
    }
}
