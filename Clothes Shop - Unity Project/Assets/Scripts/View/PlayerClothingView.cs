using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClothingView : MonoBehaviour
{
    public SpriteRenderer hoodRenderer;
    public SpriteRenderer torsoRenderer;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        ClothingStaticEvents.OnRequestedClothingEquip += OnRequestedClothingEquip;
    }

    private void OnDisable()
    {
        ClothingStaticEvents.OnRequestedClothingEquip -= OnRequestedClothingEquip;
    }

    public void VisualizePiece(ClothingPieceSettings clothingPiece)
    {
        if (clothingPiece.pieceType == ClothingPieceTypes.Hood)
        {
            hoodRenderer.sprite = clothingPiece.pieceSprite;
        }
        else if(clothingPiece.pieceType == ClothingPieceTypes.Torso)
        {
            torsoRenderer.sprite = clothingPiece.pieceSprite;
        }
    }

    private void OnRequestedClothingEquip(ClothingPieceSettings clothingPiece)
    {
        VisualizePiece(clothingPiece);
    }
}
