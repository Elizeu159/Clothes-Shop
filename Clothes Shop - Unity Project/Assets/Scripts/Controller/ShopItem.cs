using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Button tryBttn;
    [SerializeField] private Button buyBttn;
    [SerializeField] private Button sellBttn;

    [SerializeField] private GameObject equippedWarning;

    public ClothingPieceSettings clothingPieceType;

    private void Start()
    {
        tryBttn.onClick.AddListener(Try);
        buyBttn.onClick.AddListener(Buy);
        sellBttn.onClick.AddListener(Sell);
    }

    private void OnEnable()
    {
        ClothingStaticEvents.OnRequestedClothingTry += OnRequestedClothingTry;
    }

    private void OnDisable()
    {
        ClothingStaticEvents.OnRequestedClothingTry -= OnRequestedClothingTry;
    }

    public void Setup(ClothingPieceSettings clothingPiece, bool isAlreadyTrying)
    {
        clothingPieceType = clothingPiece;
        text.text = clothingPieceType.pieceName;

        equippedWarning.SetActive(clothingPieceType.equipped);
        tryBttn.gameObject.SetActive(!clothingPieceType.equipped);
        buyBttn.gameObject.SetActive(!clothingPieceType.equipped);
        sellBttn.gameObject.SetActive(!clothingPieceType.equipped);

        tryBttn.interactable = !isAlreadyTrying;
        buyBttn.interactable = !clothingPieceType.owned;
        sellBttn.interactable = clothingPieceType.owned;
    }

    public void Try()
    {
        ClothingStaticEvents.OnRequestedClothingTry(clothingPieceType);
    }

    public void Buy()
    {
        buyBttn.interactable = false;
        sellBttn.interactable = true;
        ClothingStaticEvents.OnRequestedClothingBuy(clothingPieceType);
    }

    public void Sell()
    {
        if(clothingPieceType.equipped)
        {
            return;
        }

        buyBttn.interactable = true;
        sellBttn.interactable = false;
        ClothingStaticEvents.OnRequestedClothingSell(clothingPieceType);
    }

    private void OnRequestedClothingTry(ClothingPieceSettings clothingPiece)
    {
        tryBttn.interactable = clothingPiece != clothingPieceType;
    }
}
