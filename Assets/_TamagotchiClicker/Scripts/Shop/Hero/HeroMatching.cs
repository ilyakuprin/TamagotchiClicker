using UnityEngine;
using UnityEngine.UI;
using System;
using Zenject;

namespace TamagotchiClicker
{
    [Serializable]
    public struct Hero
    {
        public Image Image;
        public Button Buy;
        public Sprite Active;
    }

    public class HeroMatching : MonoBehaviour
    {
        [SerializeField] private Hero[] _hero;

        private Saving _saving;

        [Inject]
        private void Construct(Saving saving)
        {
            _saving = saving;
        }

        public void Show()
        {
            //for (int i = 0; i < UPPER; i++)
            
        }

        private void OnEnable()
            => _saving.SaveDataReceived += Show;

        private void OnDisable()
            => _saving.SaveDataReceived -= Show;
    }
}
