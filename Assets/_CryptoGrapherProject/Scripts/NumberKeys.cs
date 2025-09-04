using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NumberKeys : MonoBehaviour
{
    [SerializeField] private NumberKeysView _aimKeysView;
    [SerializeField] private NumberKeysView _currentKeysView;
    [SerializeField] private Button _applyFirstButton;
    [SerializeField] private Button _applySecondButton;
    [SerializeField] private Button _applyThirdButton;
    [SerializeField] private UnityEvent _gameWon;

    private int[] aimKeyValues = new int[3];
    private int[] currentKeyValues = new int[3];

    private bool KeyMatch
    {
        get
        {
            if (aimKeyValues[0] == currentKeyValues[0] && aimKeyValues[1] == currentKeyValues[1] && aimKeyValues[2] == currentKeyValues[2]) return true;
            else return false;
        }
    }

    public void StartGame()
    {
        aimKeyValues = GenerateKeys();
        //aimKeyValues = new int[] { 1, 9, 2 }; // cheat for test
        _aimKeysView.DisplayNumbers(aimKeyValues);

        currentKeyValues = GenerateKeys();
        //currentKeyValues = new int[] { 0, 0, 0 };   // cheat for test
        _currentKeysView.DisplayNumbers(currentKeyValues);
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

        _currentKeysView.DisplayNumbers(currentKeyValues);

        if (KeyMatch) _gameWon.Invoke();
    }

    public void OnClickSecondApply()
    {
        currentKeyValues[0] += 1;
        if (currentKeyValues[0] > 9) currentKeyValues[0] = 0;
        currentKeyValues[2] -= 2;
        if (currentKeyValues[2] < 0) currentKeyValues[2] = 10 + currentKeyValues[2];

        _currentKeysView.DisplayNumbers(currentKeyValues);

        if (KeyMatch) _gameWon.Invoke();
    }

    public void OnClickThirdApply()
    {
        currentKeyValues[1] += 1;
        if (currentKeyValues[1] > 9) currentKeyValues[1] = 0;
        currentKeyValues[2] -= 1;
        if (currentKeyValues[2] < 0) currentKeyValues[2] = 9;

        _currentKeysView.DisplayNumbers(currentKeyValues);

        if (KeyMatch) _gameWon.Invoke();
    }
}
