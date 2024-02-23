using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TamagotchiClicker
{
    public class FillingClick : MonoBehaviour
    {
        public event Action Filled;

        private const float MaxFill = 1f;

        [field: SerializeField] public Image Filling { get; private set; }
        
        private FillingClickConfig _fillingClickConfig;
        private HeroView _heroView;

        [Inject]
        public void Construct(FillingClickConfig fillingClickConfig,
                              HeroView heroView)
        {
            _fillingClickConfig = fillingClickConfig;
            _heroView = heroView;
        }

        private void Awake()
            => Filling.fillAmount = 0;

        private void Fill()
        {
            Filling.fillAmount += _fillingClickConfig.OneClickFilling;
            
            Filled?.Invoke();
        }

        public void FullFill()
            => Filling.fillAmount = MaxFill;

        private void OnEnable()
            => _heroView.Pressed += Fill;

        private void OnDisable()
            => _heroView.Pressed -= Fill;
    }
}
