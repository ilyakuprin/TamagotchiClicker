using UnityEngine;
using Zenject;

namespace TamagotchiClicker
{
    public class ShopHeroInstaller : MonoInstaller
    {
        [SerializeField] private HeroMatching _heroMatching;
        [SerializeField] private BackMusicView _backMusicView;
        [SerializeField] private ChangingBackground _changingBackground;

        public override void InstallBindings()
        {
            Container.Bind<HeroMatching>().FromInstance(_heroMatching).AsSingle();
            Container.Bind<BackMusicView>().FromInstance(_backMusicView).AsSingle();
            Container.Bind<ChangingBackground>().FromInstance(_changingBackground).AsSingle();

            Container.BindInterfacesAndSelfTo<ChangingHeroBackMusic>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActivatingHeroBuyButton>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuyingHero>().AsSingle();
            Container.BindInterfacesAndSelfTo<ChangingHeroOnScreen>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingSelectedHero>().AsSingle();
        }
    }
}
