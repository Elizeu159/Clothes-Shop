using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClothingView : MonoBehaviour
{
    public SpriteRenderer hoodRenderer;
    public SpriteRenderer torsoRenderer;
    public SpriteRenderer pelvisRenderer;
    public SpriteRenderer leftShoulderRenderer;
    public SpriteRenderer rightShoulderRenderer;
    public SpriteRenderer leftWristRenderer;
    public SpriteRenderer rightWristRenderer;
    public SpriteRenderer leftElbowRenderer;
    public SpriteRenderer rightElbowRenderer;
    public SpriteRenderer leftLegRenderer;
    public SpriteRenderer rightLegRenderer;
    public SpriteRenderer leftBootRenderer;
    public SpriteRenderer rightBootRenderer;

    private void OnEnable()
    {
        ClothingStaticEvents.OnRequestedClothingEquip += OnRequestedClothingEquip;
        ClothingStaticEvents.OnRequestedClothingTry += OnRequestedClothingTry;
    }

    private void OnDisable()
    {
        ClothingStaticEvents.OnRequestedClothingEquip -= OnRequestedClothingEquip;
        ClothingStaticEvents.OnRequestedClothingTry -= OnRequestedClothingTry;
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
        else if (clothingPiece.pieceType == ClothingPieceTypes.Pelvis)
        {
            pelvisRenderer.sprite = clothingPiece.pieceSprite;
        }
        else if (clothingPiece.pieceType == ClothingPieceTypes.Left_Shoulder)
        {
            leftShoulderRenderer.sprite = clothingPiece.pieceSprite;
        }
        else if (clothingPiece.pieceType == ClothingPieceTypes.Right_Shoulder)
        {
            rightShoulderRenderer.sprite = clothingPiece.pieceSprite;
        }
        else if (clothingPiece.pieceType == ClothingPieceTypes.Left_Wrist)
        {
            leftWristRenderer.sprite = clothingPiece.pieceSprite;
        }
        else if (clothingPiece.pieceType == ClothingPieceTypes.Right_Wrist)
        {
            rightWristRenderer.sprite = clothingPiece.pieceSprite;
        }
        else if (clothingPiece.pieceType == ClothingPieceTypes.Left_Elbow)
        {
            leftElbowRenderer.sprite = clothingPiece.pieceSprite;
        }
        else if (clothingPiece.pieceType == ClothingPieceTypes.Right_Elbow)
        {
            rightElbowRenderer.sprite = clothingPiece.pieceSprite;
        }
        else if (clothingPiece.pieceType == ClothingPieceTypes.Left_Leg)
        {
            leftLegRenderer.sprite = clothingPiece.pieceSprite;
        }
        else if (clothingPiece.pieceType == ClothingPieceTypes.Right_Leg)
        {
            rightLegRenderer.sprite = clothingPiece.pieceSprite;
        }
        else if (clothingPiece.pieceType == ClothingPieceTypes.Left_Boot)
        {
            leftBootRenderer.sprite = clothingPiece.pieceSprite;
        }
        else if (clothingPiece.pieceType == ClothingPieceTypes.Right_Boot)
        {
            rightBootRenderer.sprite = clothingPiece.pieceSprite;
        }
    }

    private void OnRequestedClothingEquip(ClothingPieceSettings clothingPiece)
    {
        VisualizePiece(clothingPiece);
    }

    private void OnRequestedClothingTry(ClothingPieceSettings clothingPiece)
    {
        VisualizePiece(clothingPiece);
    }
}
