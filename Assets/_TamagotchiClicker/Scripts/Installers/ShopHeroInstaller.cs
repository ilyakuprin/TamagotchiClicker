using UnityEngine;
using Zenject;

namespace TamagotchiClicker
{
    public class ShopHeroInstaller : MonoInstaller
    {
        [SerializeField] private HeroMatching _heroMatching;
        [SerializeField] private BackMusicView _backMusicView;

        public override void InstallBindings()
        {
            Container.Bind<HeroMatching>().FromInstance(_heroMatching).AsSingle();
            Container.Bind<BackMusicView>().FromInstance(_backMusicView).AsSingle();

            Container.BindInterfacesAndSelfTo<ChangingHeroBackMusic>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActivatingHeroBuyButton>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuyingHero>().AsSingle();
            Container.BindInterfacesAndSelfTo<ChangingHeroOnScreen>().AsSingle();
        }
    }
}
