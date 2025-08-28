using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayTimer : MonoBehaviour
{
    [SerializeField] private PlayTimerView _timerView;
    [SerializeField] private UnityEvent _timerFinished;
    [SerializeField] private float _startTime = 60f;
    [SerializeField] private float _countdownInterval = 0.1f;

    private Coroutine _timerCoroutine;
    public bool IsTimerCoroutineActive => _timerCoroutine != null;

    public void StartTimer()
    {
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
            _timerView.Display(remainingTime);
        }
        while (remainingTime > 0);

        _timerCoroutine = null;
        _timerFinished.Invoke();
    }
}
