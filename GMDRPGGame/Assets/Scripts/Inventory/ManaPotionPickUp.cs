using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Control;
using RPG.Items;

public class ManaPotionPickUp : MonoBehaviour
{
    InventorySystem inventory;
    UI_Inventory uiInventory;

    private void OnTriggerEnter(Collider other)
    {
        if (inventory == null)
        {
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetInventorySystem();

        }

        if (uiInventory == null)
        {
            uiInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetUI_Inventory();
        }

        if (other.gameObject.tag == "Player")
        {
            inventory.AddItem(new InventoryItem { itemType = InventoryItem.ItemType.ManaPotion, amount = 1 });
            uiInventory.RefreshInventoryItems();
            Destroy(gameObject);
        }
    }
}
