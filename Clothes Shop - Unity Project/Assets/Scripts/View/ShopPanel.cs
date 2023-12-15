using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopPanel : MonoBehaviour
{
    public GameManager gameManager;

    public Button openBttn;
    public Button closeBttn;

    public GameObject shopVisualizationHolder;
    public TMP_Text moneyText;

    public ShopItem shopItemPrefab;
    public Transform shopItemsParent;

    public List<ClothingPieceSettings> currentCategoryPieces = new List<ClothingPieceSettings>();
    public List<ShopItem> spawnedShopItems = new List<ShopItem>();

    public List<ClothingPieceSettings> allPreviewedPieces = new List<ClothingPieceSettings>();

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>(true);
        openBttn.onClick.AddListener(OpenShop);
        closeBttn.onClick.AddListener(CloseShop);

        openBttn.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        ClothingStaticEvents.OnRequestedClothingTry += OnRequestedClothingTry;
        ClothingStaticEvents.OnNearShopStateChanged += OnNearShopStateChanged;
        PlayerData.OnMoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        ClothingStaticEvents.OnRequestedClothingTry -= OnRequestedClothingTry;
        ClothingStaticEvents.OnNearShopStateChanged -= OnNearShopStateChanged;
        PlayerData.OnMoneyChanged -= OnMoneyChanged;
    }

    private void OpenShop()
    {
        OnMoneyChanged(PlayerData.GetMoneyValue());
        allPreviewedPieces.Clear();

        ClothingStaticEvents.OnShopStateChanged(true);
        shopVisualizationHolder.SetActive(true);
    }

    private void OnMoneyChanged(int value)
    {
        moneyText.text = value.ToString();
    }

    private void CloseShop()
    {
        allPreviewedPieces.Clear();

        ClothingStaticEvents.OnShopStateChanged(false);
        shopVisualizationHolder.SetActive(false);
    }

    public void ShowPiecesOfType(ClothingPieceTypes clothing)
    {
        currentCategoryPieces.Clear();

        for (int i = 0; i < gameManager.clothingItemsHolder.clothings.Length; i++)
        {
            if (clothing == gameManager.clothingItemsHolder.clothings[i].pieceType)
            {
                currentCategoryPieces.Add(gameManager.clothingItemsHolder.clothings[i]);
            }
        }

        int amountOfItemsToSpawn = currentCategoryPieces.Count - spawnedShopItems.Count;

        for (int i = 0; i < amountOfItemsToSpawn; i++)
        {
            ShopItem tempItem = Instantiate(shopItemPrefab, shopItemsParent).GetComponent<ShopItem>();
            spawnedShopItems.Add(tempItem);
        }

        for (int i = 0; i < spawnedShopItems.Count; i++)
        {
            if (currentCategoryPieces.Count > i)
            {
                spawnedShopItems[i].Setup(currentCategoryPieces[i], allPreviewedPieces.Contains(currentCategoryPieces[i]));
                spawnedShopItems[i].gameObject.SetActive(true);
            }
            else
            {
                spawnedShopItems[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnNearShopStateChanged(bool state)
    {
        openBttn.gameObject.SetActive(state);
    }

    private void OnRequestedClothingTry(ClothingPieceSettings clothingPiece)
    {
        for (int i = 0; i < allPreviewedPieces.Count; i++)
        {
            if(clothingPiece.pieceType == allPreviewedPieces[i].pieceType)
            {
                allPreviewedPieces.Remove(allPreviewedPieces[i]);
                break;
            }
        }

        allPreviewedPieces.Add(clothingPiece);
    }
}
