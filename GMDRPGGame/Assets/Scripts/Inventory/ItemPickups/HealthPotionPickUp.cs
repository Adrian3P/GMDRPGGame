using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Control;
using RPG.Items;

public class HealthPotionPickUp : ItemPickupBase
{
    public override void addItemToInventory()
    {
        inventory.AddItem(new InventoryItem { itemType = InventoryItem.ItemType.HealthPotion, amount = 1 });
        uiInventory.RefreshInventoryItems();
        Destroy(this.gameObject);
    }
}
