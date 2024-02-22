using System;
using UnityEngine;
using Zenject;

namespace TamagotchiClicker
{
    public class ChangingHeroBackMusic : IInitializable, IDisposable
    {
        private readonly HeroMatching _heroMatching;
        private readonly BackMusicView _backMusicView;

        public ChangingHeroBackMusic(HeroMatching heroMatching,
                                     BackMusicView backMusicView)
        {
            _heroMatching = heroMatching;
            _backMusicView = backMusicView;
        }

        public void Initialize()
            => SubscribeOnBuyButton();

        private void SubscribeOnBuyButton()
        {
            for (var i = 0; i < _heroMatching.GetLength(); i++)
            {
                var hero = _heroMatching.Get(i);
                var backMusic = hero.BackMusic;
                hero.Buy.onClick.AddListener(() => ChangeAudio(backMusic));
            }
        }

        private void UnsubscribeOnBuyButton()
        {
            for (var i = 0; i < _heroMatching.GetLength(); i++)
            {
                var hero = _heroMatching.Get(i);
                var backMusic = hero.BackMusic;
                hero.Buy.onClick.RemoveListener(() => ChangeAudio(backMusic));
            }
        }

        public void ChangeAudio(AudioClip audioClip)
        {
            _backMusicView.Change(audioClip);
        }

        public void Dispose()
            => UnsubscribeOnBuyButton();
    }
}
