using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TamagotchiClicker
{
    public class FillingClick : MonoBehaviour
    {
        public event Action Filled;

        [field: SerializeField] public Image Filling { get; private set; }
        
        private FillingClickConfig _fillingClickConfig;
        private HeroButtonView _heroButtonView;

        [Inject]
        public void Construct(FillingClickConfig fillingClickConfig,
                              HeroButtonView heroButtonView)
        {
            _fillingClickConfig = fillingClickConfig;
            _heroButtonView = heroButtonView;
        }

        private void Awake()
            => Filling.fillAmount = 0;

        private void Fill()
        {
            Filling.fillAmount += _fillingClickConfig.OneClickFilling;
            
            Filled?.Invoke();
        } 

        private void OnEnable()
            => _heroButtonView.Pressed += Fill;

        private void OnDisable()
            => _heroButtonView.Pressed -= Fill;
    }
}
