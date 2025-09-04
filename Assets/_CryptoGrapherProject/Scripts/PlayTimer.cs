using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayTimer : MonoBehaviour
{
    [SerializeField] private PlayTimerView _lightModeTimerView;
    [SerializeField] private PlayTimerView _hardModeTimerView;
    [SerializeField] private UnityEvent _timerFinished;
    [SerializeField] private float _startTime = 60f;
    [SerializeField] private float _countdownInterval = 0.1f;

    private Coroutine _timerCoroutine;
    public bool IsTimerCoroutineActive => _timerCoroutine != null;
    private string _gameMode;

    public void StartTimer(string mode)
    {
        _gameMode = mode;
        StopCoroutineIfActive();
        StartCoroutine();
    }

    public void StopTimer()
    {
        StopCoroutineIfActive();
    }

    private void StartCoroutine()
    {
        _timerCoroutine = StartCoroutine(TimerCountdown(_startTime, _countdownInterval));
    }

    public void StopCoroutineIfActive()
    {
        if (IsTimerCoroutineActive)
        {
            StopCoroutine(_timerCoroutine);
            _timerCoroutine = null;
        }
    }

    private IEnumerator TimerCountdown(float startTime, float countdownInterval)
    {
        
        float remainingTime = startTime;
        WaitForSeconds waitForSeconds = new(countdownInterval);
        do
        {
            yield return waitForSeconds;
            remainingTime -= countdownInterval;
            remainingTime = Mathf.Max(remainingTime, 0f);
            if (_gameMode == "light") _lightModeTimerView.Display(remainingTime);
            else if (_gameMode == "hard") _hardModeTimerView.Display(remainingTime);
        }
        while (remainingTime > 0);

        _timerCoroutine = null;
        _timerFinished.Invoke();
    }
}
