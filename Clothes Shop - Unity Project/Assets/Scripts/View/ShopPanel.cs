using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    public GameManager gameManager;

    public Button openCloseBttn;
    public GameObject shopVisualizationHolder;

    public ShopItem shopItemPrefab;
    public Transform shopItemsParent;

    public List<ClothingPieceSettings> currentCategoryPieces = new List<ClothingPieceSettings>();
    public List<ShopItem> spawnedShopItems = new List<ShopItem>();

    public List<ClothingPieceSettings> allPreviewedPieces = new List<ClothingPieceSettings>();

    private void OnEnable()
    {
        ClothingStaticEvents.OnRequestedClothingTry += OnRequestedClothingTry;
        ClothingStaticEvents.OnInventoryStateChanged += OnInventoryStateChanged;
    }

    private void OnDisable()
    {
        ClothingStaticEvents.OnRequestedClothingTry -= OnRequestedClothingTry;
        ClothingStaticEvents.OnInventoryStateChanged -= OnInventoryStateChanged;
    }

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>(true);
        openCloseBttn.onClick.AddListener(ChangeShopActiveState);
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

    private void ChangeShopActiveState()
    {
        allPreviewedPieces.Clear();

        bool isTurnedOn = shopVisualizationHolder.activeInHierarchy;

        ClothingStaticEvents.OnShopStateChanged(!isTurnedOn);

        shopVisualizationHolder.SetActive(!isTurnedOn);
    }

    private void OnInventoryStateChanged(bool state)
    {
        openCloseBttn.gameObject.SetActive(!state);
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
