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
}
