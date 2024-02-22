using UnityEngine;

namespace TamagotchiClicker
{
    public class BackMusicView : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        public void Change(AudioClip clip)
        {
            if (_audioSource.clip != clip)
            {
                _audioSource.clip = clip;
                _audioSource.Play();
            }
        }
    }
}
