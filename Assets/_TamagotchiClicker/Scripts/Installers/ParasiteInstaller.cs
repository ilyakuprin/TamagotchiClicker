using UnityEngine;
using Zenject;

namespace TamagotchiClicker
{
    public class ParasiteInstaller : MonoInstaller
    {
        [SerializeField] private ParasiteConfig _parasiteConfig;
        [SerializeField] private ParasiteView _parasiteView;

        public override void InstallBindings()
        {
            Container.Bind<ParasiteConfig>().FromInstance(_parasiteConfig).AsSingle();
            Container.Bind<ParasiteView>().FromInstance(_parasiteView).AsSingle();

            Container.BindInterfacesAndSelfTo<AppearanceParasite>().AsSingle().WithArguments(_parasiteConfig);

            Container.BindInterfacesAndSelfTo<SettingActivationClicks>().AsSingle();
            Container.BindInterfacesAndSelfTo<MovingParasite>().AsSingle();
            Container.BindInterfacesAndSelfTo<SettingActivationParasite>().AsSingle();
            Container.BindInterfacesAndSelfTo<ClickingParasite>().AsSingle();
            Container.BindInterfacesAndSelfTo<ParasiteActivity>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SubscribeParasiteActivity>().AsSingle();
        }
    }
}
