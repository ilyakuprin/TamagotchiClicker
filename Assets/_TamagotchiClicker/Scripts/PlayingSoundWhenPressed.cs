using UnityEngine;

namespace TamagotchiClicker
{
    public class PlayingSoundWhenPressed : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        protected void Play()
        {
            _audioSource.Play();
        }
    }
}
