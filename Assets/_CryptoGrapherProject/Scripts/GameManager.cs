using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _menuScreen;
    [SerializeField] private GameObject _playScreen;
    [SerializeField] private GameObject _wonScreen;
    [SerializeField] private GameObject _lostScreen;
    [SerializeField] private PlayTimer _timer;
    [SerializeField] private NumberKeys _numberKeys;

    private void Start()
    {
        SwitchToMenuScreen();
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }

    public void SwitchToMenuScreen()
    {
        _menuScreen.SetActive(true);
        _playScreen.SetActive(false);
        _wonScreen.SetActive(false);
        _lostScreen.SetActive(false);
    }

    private void SwitchToPlayScreen()
    {
        _playScreen.SetActive(true);
        _menuScreen.SetActive(false);
        _wonScreen.SetActive(false);
        _lostScreen.SetActive(false);
    }

    private void SwitchToWonScreen()
    {
        _playScreen.SetActive(false);
        _menuScreen.SetActive(false);
        _wonScreen.SetActive(true);
        _lostScreen.SetActive(false);
    }

    private void SwitchToLostScreen()
    {
        _playScreen.SetActive(false);
        _menuScreen.SetActive(false);
        _wonScreen.SetActive(false);
        _lostScreen.SetActive(true);
    }

    public void OnGameStart()
    {
        SwitchToPlayScreen();
        _timer.StartTimer();
        _numberKeys.StartGame();
    }

    public void OnGameEndLost()
    {
        SwitchToLostScreen();
        _timer.StopTimer();
    }

    public void OnGameEndWon()
    {
        SwitchToWonScreen();
        _timer.StopTimer();
    }
}
