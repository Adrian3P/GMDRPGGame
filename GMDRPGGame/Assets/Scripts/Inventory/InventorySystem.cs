using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Items
{
    public class InventorySystem : MonoBehaviour
    {
        private List<InventoryItem> inventoryItems;

        public InventorySystem()
        {
            inventoryItems = new List<InventoryItem>();

            //AddItem(new InventoryItem { itemType = InventoryItem.ItemType.Sword, amount = 1 });
            //AddItem(new InventoryItem { itemType = InventoryItem.ItemType.HealthPotion, amount = 1 });
            //AddItem(new InventoryItem { itemType = InventoryItem.ItemType.Coin, amount = 1 });
            //AddItem(new InventoryItem { itemType = InventoryItem.ItemType.ManaPotion, amount = 1 });
        }

        public void AddItem(InventoryItem item)
        {
            inventoryItems.Add(item);
        }

        public List<InventoryItem> GetItemList()
        {
            return inventoryItems;
        }

        public void clearItemSlotTemplateObjects()
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("itemSlotTemplate");

            foreach (GameObject item in objects)
            {
                Destroy(item);
            }
        }
    }
}

