using Zenject;

namespace TamagotchiClicker
{
    public class PlayingSoundPressingBoostShop : PlayingSoundWhenPressed
    {
        private BoostMatching _boostMatching;

        [Inject]
        private void Constructor(BoostMatching boostMatching)
        {
            _boostMatching = boostMatching;
        }

        private void SubscribeToButtons()
        {
            for (int i = 0; i < _boostMatching.GetLength(); i++)
            {
                var index = i;
                var button = _boostMatching.Get(index);
                button.Buy.onClick.AddListener(Play);
            }
        }

        private void UnsubscribeToButtons()
        {
            for (int i = 0; i < _boostMatching.GetLength(); i++)
            {
                var index = i;
                var button = _boostMatching.Get(index);
                button.Buy.onClick.RemoveListener(Play);
            }
        }

        private void OnEnable()
            => SubscribeToButtons();

        private void OnDisable()
            => UnsubscribeToButtons();
    }
}
