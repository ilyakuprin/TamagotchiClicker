using Zenject;

namespace TamagotchiClicker
{
    public class PlayingSoundParasite : PlayingSoundWhenPressed
    {
        private ParasiteView _parasiteView;

        [Inject]
        private void Constructor(ParasiteView parasiteView)
        {
            _parasiteView = parasiteView;
        }

        private void OnEnable()
            => _parasiteView.Pressed += Play;

        private void OnDisable()
            => _parasiteView.Pressed -= Play;
    }
}
