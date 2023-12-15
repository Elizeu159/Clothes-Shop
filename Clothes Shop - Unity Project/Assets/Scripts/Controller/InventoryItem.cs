using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image icon;
    [SerializeField] private Button equipBttn;
    public ClothingPieceSettings clothingPieceType;

    private void Start()
    {
        equipBttn.onClick.AddListener(Equip);
    }

    private void OnEnable()
    {
        ClothingStaticEvents.OnRequestedClothingEquip += OnRequestedClothingEquip;
    }

    private void OnDisable()
    {
        ClothingStaticEvents.OnRequestedClothingEquip -= OnRequestedClothingEquip;
    }

    public void Setup(ClothingPieceSettings clothingPiece)
    {
        clothingPieceType = clothingPiece;
        text.text = clothingPieceType.pieceName;
        icon.sprite = clothingPieceType.pieceSprite;
        icon.type = Image.Type.Sliced;
        icon.pixelsPerUnitMultiplier = 100;

        equipBttn.interactable = !clothingPieceType.equipped;
    }

    public void Equip()
    {
        ClothingStaticEvents.OnRequestedClothingEquip(clothingPieceType);
    }

    private void OnRequestedClothingEquip(ClothingPieceSettings clothingPiece)
    {
        equipBttn.interactable = clothingPiece != clothingPieceType;

        clothingPieceType.equipped = clothingPiece == clothingPieceType;
    }
}
