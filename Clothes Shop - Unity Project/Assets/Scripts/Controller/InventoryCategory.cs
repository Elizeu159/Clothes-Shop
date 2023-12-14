using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryCategory : MonoBehaviour
{
    public ClothingPieceTypes clothingType;
    public TMP_Text toggleText;
    public Toggle toggle;
    public bool defaultOn;

    public InventoryPanel inventory;

    private void Awake()
    {
        toggle.onValueChanged.AddListener(OnChangedToggleState);
    }

    void Start()
    {
        toggleText.text = clothingType.ToString();

        if(defaultOn)
        {
            toggle.isOn = true;
            toggle.onValueChanged.Invoke(true);
            toggle.group.EnsureValidState();
        }
    }

    private void OnChangedToggleState(bool state)
    {
        if(!state)
        {
            return;
        }

        inventory.ShowOwnedPiecesOfType(clothingType);
    }
}
