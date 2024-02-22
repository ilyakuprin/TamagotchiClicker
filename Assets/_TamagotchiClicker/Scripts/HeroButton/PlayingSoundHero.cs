using Zenject;

namespace TamagotchiClicker
{
    public class PlayingSoundHero : PlayingSoundWhenPressed
    {
        private HeroView _heroView;

        [Inject]
        private void Constructor(HeroView heroView)
        {
            _heroView = heroView;
        }

        private void OnEnable()
            => _heroView.Pressed += Play;

        private void OnDisable()
            => _heroView.Pressed -= Play;
    }
}
