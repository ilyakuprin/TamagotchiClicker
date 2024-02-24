using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using YG;

namespace TamagotchiClicker
{
    public class CountdownUntilAdShown : MonoBehaviour
    {
        private const int TimeUntilAd = 3;
        private const string FormatTimer = "{0} {1}...";
        private const int OneSec = 1;

        [SerializeField] private Canvas _canvasPause;
        [SerializeField] private TextMeshProUGUI _timerText;

        private CancellationToken _ct;
        private int _countdownCounter;
        private string _startText;

        private void Awake()
        {
            _ct = _timerText.GetCancellationTokenOnDestroy();
        }

#if UNITY_EDITOR
        private void Start()
            => StartWaitTimeShow();
#endif

        private void StartWaitTimeShow()
            => WaitTimeShow().Forget();

        private async UniTask WaitTimeShow()
        {
            await UniTask.WaitForSeconds(YandexGame.Instance.infoYG.fullscreenAdInterval);

            StartAdLaunch();
        }

        private void StartAdLaunch()
        {
            PauseGame();
            RememberStartingValues();
            StartTimer();
        }

        private void PauseGame()
        {
            _canvasPause.gameObject.SetActive(true);
            Time.timeScale = 0;
            AudioListener.pause = true;
        }

        private void RememberStartingValues()
        {
            _startText = _timerText.text;
            _countdownCounter = TimeUntilAd;
        }

        private void StartTimer()
        {
            if (_countdownCounter > 0)
            {
                Timer().Forget();
            }
            else
            {
                _timerText.text = _startText;
                _canvasPause.gameObject.SetActive(false);

                YandexGame.FullscreenShow();
            }
        }

        private async UniTask Timer()
        {
            if (!_ct.IsCancellationRequested)
            {
                _timerText.text = string.Format(FormatTimer, _startText, _countdownCounter);
                await UniTask.WaitForSeconds(OneSec, true, PlayerLoopTiming.Update, _ct);
                _countdownCounter--;
                StartTimer();
            }
        }

        private void OnEnable()
            => YandexGame.CloseFullAdEvent += StartWaitTimeShow;

        private void OnDisable()
            => YandexGame.CloseFullAdEvent -= StartWaitTimeShow;
    }
}
