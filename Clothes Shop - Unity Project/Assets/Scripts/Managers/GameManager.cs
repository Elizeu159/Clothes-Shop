using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ClothingItemsHolder clothingItemsHolder;
    public PlayerClothingView clothingView;
    public PlayerInventoryManager playerInventoryManager;

    private void Awake()
    {
        // A loop used only for testing, equips the scriptable Objects flagged as equipped in editor
        for (int i = 0; i < clothingItemsHolder.clothings.Length; i++)
        {
            if (clothingItemsHolder.clothings[i].owned)
            {
                playerInventoryManager.AddClothing(clothingItemsHolder.clothings[i]);
            }
            if (clothingItemsHolder.clothings[i].equipped)
            {
                clothingView.VisualizePiece(clothingItemsHolder.clothings[i]);
            }
        }
    }

    private void OnEnable()
    {
        ClothingStaticEvents.OnShopStateChanged += OnShopStateChanged;
    }

    private void OnDisable()
    {
        ClothingStaticEvents.OnShopStateChanged -= OnShopStateChanged;
    }

    private void OnShopStateChanged(bool state)
    {
        if (state)
        {
            return;
        }

        for (int i = 0; i < clothingItemsHolder.clothings.Length; i++)
        {
            if (clothingItemsHolder.clothings[i].equipped)
            {
                clothingView.VisualizePiece(clothingItemsHolder.clothings[i]);
            }
        }
    }
}
