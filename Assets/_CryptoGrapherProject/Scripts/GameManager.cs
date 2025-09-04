using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _menuScreen;
    [SerializeField] private GameObject _lightModePlayScreen;
    [SerializeField] private GameObject _lightModeDescriptionScreen;
    [SerializeField] private GameObject _applicationQuitScreen;
    [SerializeField] private GameObject _hardModePlayScreen;
    [SerializeField] private GameObject _hardModeDescriptionScreen;
    [SerializeField] private GameObject _lightModeWonScreen;
    [SerializeField] private GameObject _hardModeWonScreen;
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

    public void OpenOverlayWindow(GameObject window)
    {
        window.SetActive(true);
    }

    public void CloseOverlayWindow(GameObject window)
    {
        window.SetActive(false);
    }

    public void SwitchToMenuScreen()
    {
        _menuScreen.SetActive(true);
        _lightModePlayScreen.SetActive(false);
        _lightModeDescriptionScreen.SetActive(false);
        _applicationQuitScreen.SetActive(false);
        _hardModePlayScreen.SetActive(false);
        _hardModeDescriptionScreen.SetActive(false);
        _lightModeWonScreen.SetActive(false);
        _hardModeWonScreen.SetActive(false);
        _lostScreen.SetActive(false);
    }

    private void SwitchToLightModePlayScreen()
    {
        _menuScreen.SetActive(false);
        _lightModePlayScreen.SetActive(true);
        _lightModeDescriptionScreen.SetActive(false);
        _applicationQuitScreen.SetActive(false);
        _hardModePlayScreen.SetActive(false);
        _hardModeDescriptionScreen.SetActive(false);
        _lightModeWonScreen.SetActive(false);
        _hardModeWonScreen.SetActive(false);
        _lostScreen.SetActive(false);
    }

    private void SwitchToLightModeWonScreen()
    {
        _menuScreen.SetActive(false);
        _lightModePlayScreen.SetActive(false);
        _lightModeDescriptionScreen.SetActive(false);
        _applicationQuitScreen.SetActive(false);
        _hardModePlayScreen.SetActive(false);
        _hardModeDescriptionScreen.SetActive(false);
        _lightModeWonScreen.SetActive(true);
        _hardModeWonScreen.SetActive(false);
        _lostScreen.SetActive(false);
    }

    private void SwitchToHardModePlayScreen()
    {
        _menuScreen.SetActive(false);
        _lightModePlayScreen.SetActive(false);
        _lightModeDescriptionScreen.SetActive(false);
        _applicationQuitScreen.SetActive(false);
        _hardModePlayScreen.SetActive(true);
        _hardModeDescriptionScreen.SetActive(false);
        _lightModeWonScreen.SetActive(false);
        _hardModeWonScreen.SetActive(false);
        _lostScreen.SetActive(false);
    }

    private void SwitchToHardModeWonScreen()
    {
        _menuScreen.SetActive(false);
        _lightModePlayScreen.SetActive(false);
        _lightModeDescriptionScreen.SetActive(false);
        _applicationQuitScreen.SetActive(false);
        _hardModePlayScreen.SetActive(false);
        _hardModeDescriptionScreen.SetActive(false);
        _lightModeWonScreen.SetActive(false);
        _hardModeWonScreen.SetActive(true);
        _lostScreen.SetActive(false);
    }

    private void SwitchToLostScreen()
    {
        _menuScreen.SetActive(false);
        _lightModePlayScreen.SetActive(false);
        _lightModeDescriptionScreen.SetActive(false);
        _applicationQuitScreen.SetActive(false);
        _hardModePlayScreen.SetActive(false);
        _hardModeDescriptionScreen.SetActive(false);
        _lightModeWonScreen.SetActive(false);
        _hardModeWonScreen.SetActive(false);
        _lostScreen.SetActive(true);
    }

    public void OnLightModeGameStart()
    {
        SwitchToLightModePlayScreen();
        _timer.StartTimer("light");
        _numberKeys.StartGame("light");
    }

    public void OnHardModeGameStart()
    {
        SwitchToHardModePlayScreen();
        _timer.StartTimer("hard");
        _numberKeys.StartGame("hard");
    }

    public void OnGameEndLost()
    {
        SwitchToLostScreen();
        _timer.StopTimer();
    }

    public void OnLightModeGameEndWon()
    {
        SwitchToLightModeWonScreen();
        _timer.StopTimer();
    }

    public void OnHardModeGameEndWon()
    {
        SwitchToHardModeWonScreen();
        _timer.StopTimer();
    }
}
