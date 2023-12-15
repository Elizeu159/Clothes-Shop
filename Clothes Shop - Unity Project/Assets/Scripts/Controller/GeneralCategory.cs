using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GeneralCategory : MonoBehaviour
{
    public ClothingPieceTypes clothingType;
    public TMP_Text toggleText;
    public Toggle toggle;
    public bool defaultOn;

    protected virtual void Awake()
    {
        toggle.onValueChanged.AddListener(OnChangedToggleState);
    }

    protected virtual void Start()
    {
        toggleText.text = clothingType.ToString();
    }

    protected virtual void OnEnable()
    {
        if (defaultOn)
        {
            toggle.isOn = true;
            toggle.onValueChanged.Invoke(true);
            toggle.group.EnsureValidState();
        }
    }

    protected virtual void OnChangedToggleState(bool state)
    {
        if (!state)
        {
            return;
        }
    }
}
