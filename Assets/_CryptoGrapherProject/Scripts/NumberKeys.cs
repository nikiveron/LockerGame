using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NumberKeys : MonoBehaviour
{
    [SerializeField] private NumberKeysView _lightModeAimKeysView;
    [SerializeField] private NumberKeysView _lightModeCurrentKeysView;
    [SerializeField] private NumberKeysView _hardModeAimKeysView;
    [SerializeField] private NumberKeysView _hardModeCurrentKeysView;
    [SerializeField] private Button _applyFirstButton;
    [SerializeField] private Button _applySecondButton;
    [SerializeField] private Button _applyThirdButton;
    [SerializeField] private UnityEvent _lightGameWon;
    [SerializeField] private UnityEvent _hardGameWon;

    private int[] aimKeyValues = new int[3];
    private int aimKeyValue;
    private int[] currentKeyValues = new int[3];
    private string _gameMode;

    private bool KeyMatch
    {
        get
        {
            if (_gameMode == "light")
            {
                if (currentKeyValues.Sum() == aimKeyValue) return true;
                else return false;
            }
            else //if (_gameMode == "hard") // for future modes extension
            {
                if (aimKeyValues[0] == currentKeyValues[0] && aimKeyValues[1] == currentKeyValues[1] && aimKeyValues[2] == currentKeyValues[2]) return true;
                else return false;
            }
        }
    }

    public void StartGame(string mode)
    {
        _gameMode = mode;
        if (_gameMode == "light")
        {
            aimKeyValue = GenerateKeys().Sum();
            _lightModeAimKeysView.DisplayNumbers(aimKeyValue);

            currentKeyValues = GenerateKeys();
            _lightModeCurrentKeysView.DisplayNumbers(currentKeyValues);

        }
        else if (_gameMode == "hard")
        {
            aimKeyValues = GenerateKeys();
            //aimKeyValues = new int[] { 1, 9, 2 }; // cheat for test
            _hardModeAimKeysView.DisplayNumbers(aimKeyValues);

            currentKeyValues = GenerateKeys();
            //currentKeyValues = new int[] { 0, 0, 0 };   // cheat for test
            _hardModeCurrentKeysView.DisplayNumbers(currentKeyValues);
        }
    }

    public int[] GenerateKeys()
    {
        System.Random rand = new System.Random();
        int[] keyValues = new int[3];
        keyValues[0] = rand.Next(0, 9);
        keyValues[1] = rand.Next(0, 9);
        keyValues[2] = rand.Next(0, 9);
        return keyValues;
    }

    public void OnClickFirstApply()
    {
        currentKeyValues[0] += 1;
        if (currentKeyValues[0] > 9) currentKeyValues[0] = 0;
        currentKeyValues[1] -= 1;
        if (currentKeyValues[1] < 0) currentKeyValues[1] = 9;
        currentKeyValues[2] += 2;
        if (currentKeyValues[2] > 9) currentKeyValues[2] = currentKeyValues[2] % 10;

        if (_gameMode == "light") _lightModeCurrentKeysView.DisplayNumbers(currentKeyValues);
        else if (_gameMode == "hard") _hardModeCurrentKeysView.DisplayNumbers(currentKeyValues);


        if (KeyMatch)
        {
            if (_gameMode == "light") _lightGameWon.Invoke();
            else if (_gameMode == "hard") _hardGameWon.Invoke();
        }
    }

    public void OnClickSecondApply()
    {
        currentKeyValues[0] += 1;
        if (currentKeyValues[0] > 9) currentKeyValues[0] = 0;
        currentKeyValues[2] -= 2;
        if (currentKeyValues[2] < 0) currentKeyValues[2] = 10 + currentKeyValues[2];

        if (_gameMode == "light") _lightModeCurrentKeysView.DisplayNumbers(currentKeyValues);
        else if (_gameMode == "hard") _hardModeCurrentKeysView.DisplayNumbers(currentKeyValues);

        if (KeyMatch)
        {
            if (_gameMode == "light") _lightGameWon.Invoke();
            else if (_gameMode == "hard") _hardGameWon.Invoke();
        }
    }

    public void OnClickThirdApply()
    {
        currentKeyValues[1] += 1;
        if (currentKeyValues[1] > 9) currentKeyValues[1] = 0;
        currentKeyValues[2] -= 1;
        if (currentKeyValues[2] < 0) currentKeyValues[2] = 9;

        if (_gameMode == "light") _lightModeCurrentKeysView.DisplayNumbers(currentKeyValues);
        else if (_gameMode == "hard") _hardModeCurrentKeysView.DisplayNumbers(currentKeyValues);

        if (KeyMatch)
        {
            if (_gameMode == "light") _lightGameWon.Invoke();
            else if (_gameMode == "hard") _hardGameWon.Invoke();
        }
    }
}
