using TMPro;
using UnityEngine;

public class PlayTimerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _outputText;

    public void Display(float remainingTime)
    {
        _outputText.text = $"{remainingTime:F0}";
    }
}
