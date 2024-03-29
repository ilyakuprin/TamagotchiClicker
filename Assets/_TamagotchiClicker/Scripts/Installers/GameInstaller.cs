using Zenject;
using UnityEngine;

namespace TamagotchiClicker
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private HeroView _heroView;
        [SerializeField] private Click _click;
        [SerializeField] private ParentCreatedClicks _parentCreatedClicks;
        [SerializeField] private FadeConfig _fadeConfig;
        [SerializeField] private CounterMoneyView _counterMoneyView;
        [SerializeField] private CostHeroesConfig _costHeroesConfig;
        
        [SerializeField] private BoostsValueConfig _boostsValueConfig;
        [SerializeField] private BoostMatching _boostMatching;
        [SerializeField] private ClickViewUi _clickViewUi;
        [SerializeField] private FillingClick _fillingClick;
        [SerializeField] private FillingClickConfig _fillingClickConfig;
        [SerializeField] private GettingStartPosition _gettingStartPosition;
        [SerializeField] private SettingMuteAudio _settingMuteAudio;
        [SerializeField] private ShowingNumberImprovements _showingNumberImprovements;
        [SerializeField] private AdvertisingAwardConfig _advertisingAwardConfig;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Saving>().AsSingle();
            Container.BindInterfacesAndSelfTo<ClickingHero>().AsSingle();
            Container.BindInterfacesAndSelfTo<CreatingClicking>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActivatingClicking>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActivatingBoostBuyButton>().AsSingle();
            Container.BindInterfacesAndSelfTo<OpeningNextBoost>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuyingBoost>().AsSingle();
            Container.BindInterfacesAndSelfTo<CalculationClick>().AsSingle();
            Container.BindInterfacesAndSelfTo<Autoclick>().AsSingle();
            Container.BindInterfacesAndSelfTo<DevastationFilling>().AsSingle();
            Container.BindInterfacesAndSelfTo<BoostingClickForClick>().AsSingle();
            Container.BindInterfacesAndSelfTo<ResettingClickBoost>().AsSingle();
            Container.BindInterfacesAndSelfTo<MemorizationPressedHeroButtonShop>().AsSingle();
            Container.BindInterfacesAndSelfTo<AdvertisingAward>().AsSingle();

            Container.Bind<HeroView>().FromInstance(_heroView).AsSingle();
            Container.Bind<Click>().FromInstance(_click).AsSingle();
            Container.Bind<ParentCreatedClicks>().FromInstance(_parentCreatedClicks).AsSingle();

            Container.Bind<FadeConfig>().FromInstance(_fadeConfig).AsSingle();

            Container.Bind<CounterMoneyView>().FromInstance(_counterMoneyView).AsSingle();

            Container.Bind<CostHeroesConfig>().FromInstance(_costHeroesConfig).AsSingle();

            Container.Bind<BoostsValueConfig>().FromInstance(_boostsValueConfig).AsSingle();
            Container.Bind<BoostMatching>().FromInstance(_boostMatching).AsSingle();

            Container.Bind<ClickViewUi>().FromInstance(_clickViewUi).AsSingle();

            Container.Bind<FillingClick>().FromInstance(_fillingClick).AsSingle();
            Container.Bind<FillingClickConfig>().FromInstance(_fillingClickConfig).AsSingle();

            Container.Bind<GettingStartPosition>().FromInstance(_gettingStartPosition).AsSingle();

            Container.Bind<SettingMuteAudio>().FromInstance(_settingMuteAudio).AsSingle();
            Container.Bind<ShowingNumberImprovements>().FromInstance(_showingNumberImprovements).AsSingle();
            Container.Bind<AdvertisingAwardConfig>().FromInstance(_advertisingAwardConfig).AsSingle();
        }
    }
}
