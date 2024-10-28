using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InputFields : MonoBehaviour
{
    [SerializeField] public TMP_InputField XInput;
    [SerializeField] public TMP_InputField YInput;
    [SerializeField] public TMP_InputField MinesInput;

    public void LoadMapSize()
    {
        if (int.TryParse(XInput.text, out int x_value))
            MapSize.x = x_value;
        if (int.TryParse(YInput.text, out int y_value))
            MapSize.y = y_value;
        if (int.TryParse(MinesInput.text, out int mines_value))
            MapSize.amountMines = mines_value;

    }

}
