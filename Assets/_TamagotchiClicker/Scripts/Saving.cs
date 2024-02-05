using System;
using YG;
using Zenject;

namespace TamagotchiClicker
{
    public class Saving : IInitializable, IDisposable
    {
        public event Action SaveDataReceived;

        public void Initialize()
        {
            OnDataReceived();
            YandexGame.GetDataEvent += OnDataReceived;
        }

        public void Save()
        {
            YandexGame.SaveProgress();
            OnDataReceived();
        }

        private void OnDataReceived()
        {
            SaveDataReceived?.Invoke();
        }

        public void Dispose()
        {
            YandexGame.GetDataEvent -= OnDataReceived;
        }
    }
}
