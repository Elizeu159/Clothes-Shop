using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    public List<ClothingPieceSettings> acquiredClothes = new List<ClothingPieceSettings>();

    private void OnEnable()
    {
        ClothingStaticEvents.OnRequestedClothingBuy += AddClothing;
        ClothingStaticEvents.OnRequestedClothingSell += RemoveClothing;
    }

    private void OnDisable()
    {
        ClothingStaticEvents.OnRequestedClothingBuy -= AddClothing;
        ClothingStaticEvents.OnRequestedClothingSell -= RemoveClothing;
    }

    public bool IsClothingOwned(ClothingPieceSettings clothingPiece)
    {
        return acquiredClothes.Contains(clothingPiece);
    }

    public void AddClothing(ClothingPieceSettings clothingPiece)
    {
        if(acquiredClothes.Contains(clothingPiece))
        {
            return;
        }

        acquiredClothes.Add(clothingPiece);
        clothingPiece.owned = true;
    }

    public void RemoveClothing(ClothingPieceSettings clothingPiece)
    {
        acquiredClothes.Remove(clothingPiece);
        clothingPiece.owned = false;
    }
}
