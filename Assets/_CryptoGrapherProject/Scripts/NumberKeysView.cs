using TMPro;
using UnityEngine;

public class NumberKeysView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _outputNumber1;
    [SerializeField] private TextMeshProUGUI _outputNumber2;
    [SerializeField] private TextMeshProUGUI _outputNumber3;

    public void DisplayNumbers(int[] numbers)
    {
        _outputNumber1.text = numbers[0].ToString();
        _outputNumber2.text = numbers[1].ToString();
        _outputNumber3.text = numbers[2].ToString();
    }

    public void DisplayNumbers(int number)
    {
        _outputNumber1.text = number.ToString();
    }

}
