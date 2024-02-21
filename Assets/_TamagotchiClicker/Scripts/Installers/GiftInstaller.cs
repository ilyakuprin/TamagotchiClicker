using UnityEngine;
using Zenject;

namespace TamagotchiClicker
{
    public class GiftInstaller : MonoInstaller
    {
        [SerializeField] private GiftConfig _giftConfig;
        [SerializeField] private GiftView _giftView;
        [SerializeField] private GettingEndPosition _gettingEndPosition;
        [SerializeField] private MovementGift _movementGift;

        public override void InstallBindings()
        {
            Container.Bind<GiftConfig>().FromInstance(_giftConfig).AsSingle();
            Container.Bind<GiftView>().FromInstance(_giftView).AsSingle();
            Container.Bind<GettingEndPosition>().FromInstance(_gettingEndPosition).AsSingle();
            Container.Bind<MovementGift>().FromInstance(_movementGift).AsSingle();

            Container.BindInterfacesAndSelfTo<AppearanceGift>().AsSingle().WithArguments(_giftConfig);

            Container.BindInterfacesAndSelfTo<MovingGift>().AsSingle();
            Container.BindInterfacesAndSelfTo<ReceivingMoneyGift>().AsSingle();
            Container.BindInterfacesAndSelfTo<SettingActivationGift>().AsSingle();
            Container.BindInterfacesAndSelfTo<StartingTimerSelectedGift>().AsSingle();
            Container.BindInterfacesAndSelfTo<StartingTimerUnselectedGift>().AsSingle();
        }
    }
}
