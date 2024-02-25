using Cysharp.Threading.Tasks;
using System.Threading;
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
        private const float BackupTime = 2.5f;

        [SerializeField] private Canvas _canvasPause;
        [SerializeField] private TextMeshProUGUI _timerText;

        private CancellationToken _ct;
        private int _countdownCounter;
        private string _startText;
        private bool _forcedStop;

        private void Awake()
        {
            _ct = _timerText.GetCancellationTokenOnDestroy();
        }

        private void Start()
            => StartWaitTimeShow();

        private void StartWaitTimeShow()
            => WaitTimeShow().Forget();

        private async UniTask WaitTimeShow()
        {
            var checking = true;

            while (checking)
            {
                if (YandexGame.timerShowAd >= YandexGame.Instance.infoYG.fullscreenAdInterval)
                {
                    StartAdLaunch();
                    checking = false;
                }

                await UniTask.WaitForSeconds(OneSec, true, PlayerLoopTiming.Update, _ct);
            }
        }

        private void StartAdLaunch()
        {
            SetActiveCanvas(true);
            PauseGame();
            RememberStartingValues();
            ShowTimerAd().Forget();
        }

        private void SetActiveCanvas(bool value)
            => _canvasPause.gameObject.SetActive(value);

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

        private async UniTask ShowTimerAd()
        {
            for (var i = _countdownCounter; i > 0; i--)
            {
                if (!_ct.IsCancellationRequested)
                {
                    _timerText.text = string.Format(FormatTimer, _startText, _countdownCounter);
                    await UniTask.WaitForSeconds(OneSec, true, PlayerLoopTiming.Update, _ct);
                    _countdownCounter--;
                }
            }

            YandexGame.FullscreenShow();

            BackupTimerClosure().Forget();

            _forcedStop = false;

            while (!YandexGame.nowFullAd || !_forcedStop)
                await UniTask.NextFrame(_ct);

            if (!_forcedStop)
            {
                Debug.Log("stop");
                SetActiveCanvas(false);
                StartWaitTimeShow();
            }
        }

        private async UniTask BackupTimerClosure()
        {
            await UniTask.WaitForSeconds(BackupTime, true, PlayerLoopTiming.Update, _ct);

            if (_canvasPause.gameObject.activeInHierarchy)
            {
                SetActiveCanvas(false);
                _forcedStop = true;
            }
        }
    }
}
