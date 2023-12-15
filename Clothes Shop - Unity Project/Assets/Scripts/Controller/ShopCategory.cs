using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopCategory : GeneralCategory
{
    public ShopPanel shopPanel;

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
        shopPanel.ShowPiecesOfType(clothingType);
    }
}
