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

            Container.BindInterfacesAndSelfTo<AppearanceParasite>().AsSingle();
            Container.BindInterfacesAndSelfTo<SettingActivationClicks>().AsSingle();
            Container.BindInterfacesAndSelfTo<MovementParasite>().AsSingle();
        }
    }
}
