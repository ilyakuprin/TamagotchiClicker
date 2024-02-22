using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class LoadingSelectedHero : IInitializable
    {
        private readonly HeroMatching _heroMatching;
        private readonly ChangingBackground _changingBackground;
        private readonly ChangingHeroBackMusic _changingHeroBackMusic;
        private readonly ChangingHeroOnScreen _changingHeroOnScreen;

        public LoadingSelectedHero(HeroMatching heroMatching,
                                   ChangingBackground changingBackground,
                                   ChangingHeroBackMusic changingHeroBackMusic,
                                   ChangingHeroOnScreen changingHeroOnScreen)
        {
            _heroMatching = heroMatching;
            _changingBackground = changingBackground;
            _changingHeroBackMusic = changingHeroBackMusic;
            _changingHeroOnScreen = changingHeroOnScreen;
        }

        public void Initialize()
            => Load();

        private void Load()
        {
            var hero = _heroMatching.Get(YandexGame.savesData.IndexSelectedHero);

            _changingBackground.ChangeSprite(hero.Background);
            _changingHeroBackMusic.ChangeAudio(hero.BackMusic);
            _changingHeroOnScreen.ChangeSprite(hero.Active);
        }
    }
}
