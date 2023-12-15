using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryCategory : GeneralCategory
{
    public InventoryPanel inventory;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnChangedToggleState(bool state)
    {
        if (!state)
        {
            return;
        }
        inventory.ShowOwnedPiecesOfType(clothingType);
    }
}
