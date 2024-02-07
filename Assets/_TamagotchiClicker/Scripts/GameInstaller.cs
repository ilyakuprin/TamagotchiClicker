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

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Saving>().AsSingle();
            Container.BindInterfacesAndSelfTo<ClickingHero>().AsSingle();
            Container.BindInterfacesAndSelfTo<CreatingClicking>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActivatingClicking>().AsSingle();

            Container.Bind<HeroButtonView>().FromInstance(_heroButtonView).AsSingle();
            Container.Bind<Clicking>().FromInstance(_clicking).AsSingle();
            Container.Bind<ParentCreatedClicks>().FromInstance(_parentCreatedClicks).AsSingle();

            Container.Bind<FadeConfig>().FromInstance(_fadeConfig).AsSingle();

            Container.Bind<CounterMoneyView>().FromInstance(_counterMoneyView).AsSingle();

            Container.Bind<CostHeroesConfig>().FromInstance(_costHeroesConfig).AsSingle();
        }
    }
}
