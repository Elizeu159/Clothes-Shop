using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggersController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "ShopTrigger")
        {
            ClothingStaticEvents.OnNearShopStateChanged(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "ShopTrigger")
        {
            ClothingStaticEvents.OnNearShopStateChanged(false);
        }
    }
}
