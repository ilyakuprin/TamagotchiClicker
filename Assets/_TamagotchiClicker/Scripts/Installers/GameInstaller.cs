using Zenject;
using UnityEngine;

namespace TamagotchiClicker
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private HeroButtonView _heroButtonView;
        [SerializeField] private Clicking _clicking;
        [SerializeField] private ParentCreatedClicks _parentCreatedClicks;
        [SerializeField] private FadeConfig _fadeConfig;
        [SerializeField] private CounterMoneyView _counterMoneyView;
        [SerializeField] private CostHeroesConfig _costHeroesConfig;
        [SerializeField] private HeroMatching _heroMatching;
        [SerializeField] private BoostsValueConfig _boostsValueConfig;
        [SerializeField] private BoostMatching _boostMatching;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Saving>().AsSingle();
            Container.BindInterfacesAndSelfTo<ClickingHero>().AsSingle();
            Container.BindInterfacesAndSelfTo<CreatingClicking>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActivatingClicking>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActivatingHeroBuyButton>().AsSingle();
            Container.BindInterfacesAndSelfTo<ChangingHeroOnScreen>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuyingHero>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActivatingBoostBuyButton>().AsSingle();
            Container.BindInterfacesAndSelfTo<OpeningNextBoost>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuyingBoost>().AsSingle();

            Container.Bind<HeroButtonView>().FromInstance(_heroButtonView).AsSingle();
            Container.Bind<Clicking>().FromInstance(_clicking).AsSingle();
            Container.Bind<ParentCreatedClicks>().FromInstance(_parentCreatedClicks).AsSingle();

            Container.Bind<FadeConfig>().FromInstance(_fadeConfig).AsSingle();

            Container.Bind<CounterMoneyView>().FromInstance(_counterMoneyView).AsSingle();

            Container.Bind<CostHeroesConfig>().FromInstance(_costHeroesConfig).AsSingle();
            Container.Bind<HeroMatching>().FromInstance(_heroMatching).AsSingle();

            Container.Bind<BoostsValueConfig>().FromInstance(_boostsValueConfig).AsSingle();
            Container.Bind<BoostMatching>().FromInstance(_boostMatching).AsSingle();
        }
    }
}
