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

    [SerializeField] private TMP_Text buyPrice;
    [SerializeField] private TMP_Text sellPrice;

    [SerializeField] private Image icon;
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
        icon.sprite = clothingPieceType.pieceSprite;
        icon.type = Image.Type.Sliced;
        icon.pixelsPerUnitMultiplier = 100;

        sellPrice.text = clothingPieceType.sellPrice.ToString();
        buyPrice.text = clothingPieceType.buyPrice.ToString();

        equippedWarning.SetActive(clothingPieceType.equipped);
        tryBttn.gameObject.SetActive(!clothingPieceType.equipped);
        buyBttn.gameObject.SetActive(!clothingPieceType.equipped && !clothingPieceType.owned);
        sellBttn.gameObject.SetActive(!clothingPieceType.equipped && clothingPieceType.owned);

        tryBttn.interactable = !isAlreadyTrying;
    }

    public void Try()
    {
        ClothingStaticEvents.OnRequestedClothingTry(clothingPieceType);
    }

    public void Buy()
    {
        if (PlayerData.GetMoneyValue() < clothingPieceType.buyPrice)
        {
            return;
        }
        buyBttn.gameObject.SetActive(false);
        sellBttn.gameObject.SetActive(true);
        PlayerData.ChangeMoneyValue(-clothingPieceType.buyPrice);
        ClothingStaticEvents.OnRequestedClothingBuy(clothingPieceType);
    }

    public void Sell()
    {
        if(clothingPieceType.equipped)
        {
            return;
        }

        buyBttn.gameObject.SetActive(true);
        sellBttn.gameObject.SetActive(false);
        PlayerData.ChangeMoneyValue(+clothingPieceType.sellPrice);
        ClothingStaticEvents.OnRequestedClothingSell(clothingPieceType);
    }

    private void OnRequestedClothingTry(ClothingPieceSettings clothingPiece)
    {
        tryBttn.interactable = clothingPiece != clothingPieceType;
    }
}
