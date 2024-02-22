using Zenject;

namespace TamagotchiClicker
{
    public class PlayingSoundGift : PlayingSoundWhenPressed
    {
        private GiftView _giftView;

        [Inject]
        private void Constructor(GiftView giftView)
        {
            _giftView = giftView;
        }

        private void OnEnable()
            => _giftView.Pressed += Play;

        private void OnDisable()
            => _giftView.Pressed -= Play;
    }
}