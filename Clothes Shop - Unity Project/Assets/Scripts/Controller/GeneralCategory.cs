using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class GeneralCategory : MonoBehaviour
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
        string correctedClothingTypeString = clothingType.ToString().Replace('_', ' ');
        toggleText.text = correctedClothingTypeString;
    }

    protected virtual void OnEnable()
    {
        toggle.isOn = defaultOn;
        toggle.onValueChanged.Invoke(defaultOn);
        //if (defaultOn)
        //{
            toggle.group.EnsureValidState();
        //}
    }

    protected abstract void OnChangedToggleState(bool state);
}
