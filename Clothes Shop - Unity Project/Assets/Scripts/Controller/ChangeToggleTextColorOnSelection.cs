using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Toggle))]
public class ChangeToggleTextColorOnSelection : MonoBehaviour
{
    private Toggle _toggle;

    public TMP_Text toggleText;

    public Color nonSelectedColor;
    public Color selectedColor;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
        _toggle.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(bool state)
    {
        if(state)
        {
            toggleText.color = selectedColor;
        }
        else
        {
            toggleText.color = nonSelectedColor;
        }
    }
   
}
