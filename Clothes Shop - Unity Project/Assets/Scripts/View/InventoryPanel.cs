using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    public GameManager gameManager;

    public Button openCloseBttn;
    public GameObject inventoryVisualizationHolder;

    public InventoryItem inventoryItemPrefab;
    public Transform inventoryItemsParent;

    public List<ClothingPieceSettings> clothingsToDisplay = new List<ClothingPieceSettings>();
    public List<InventoryItem> spawnedInventoryItems = new List<InventoryItem>();

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>(true);
        openCloseBttn.onClick.AddListener(ChangeIventoryActiveState);
    }

    private void OnEnable()
    {
        ClothingStaticEvents.OnShopStateChanged += OnShopStateChanged;
    }

    private void OnDisable()
    {
        ClothingStaticEvents.OnShopStateChanged -= OnShopStateChanged;
    }

    public void ShowOwnedPiecesOfType(ClothingPieceTypes clothing)
    {
        clothingsToDisplay.Clear();

        for (int i = 0; i < gameManager.playerInventoryManager.acquiredClothes.Count; i++)
        {
            if(clothing == gameManager.playerInventoryManager.acquiredClothes[i].pieceType)
            {
                clothingsToDisplay.Add(gameManager.playerInventoryManager.acquiredClothes[i]);
            }
        }

        int amountOfInventoryItemsToSpawn = clothingsToDisplay.Count - spawnedInventoryItems.Count;

        for (int i = 0; i < amountOfInventoryItemsToSpawn; i++)
        {
            InventoryItem tempItem = Instantiate(inventoryItemPrefab, inventoryItemsParent).GetComponent<InventoryItem>();
            spawnedInventoryItems.Add(tempItem);
        }

        for (int i = 0; i < spawnedInventoryItems.Count; i++)
        {
            if(clothingsToDisplay.Count > i)
            {
                spawnedInventoryItems[i].Setup(clothingsToDisplay[i]);
                spawnedInventoryItems[i].gameObject.SetActive(true);
            }
            else
            {
                spawnedInventoryItems[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnShopStateChanged(bool state)
    {
        openCloseBttn.gameObject.SetActive(!state);
    }

    private void ChangeIventoryActiveState()
    {
        bool isTurnedOn = inventoryVisualizationHolder.activeInHierarchy;

        inventoryVisualizationHolder.SetActive(!isTurnedOn);
    }

}
