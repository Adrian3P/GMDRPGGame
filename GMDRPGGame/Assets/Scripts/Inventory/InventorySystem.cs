using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Items
{
    public class InventorySystem
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

        public void DeleteItem(int index)
        {
            if (inventoryItems[index].amount == 0)
            {
                inventoryItems.RemoveAt(index);
            }
            else
            {
                inventoryItems[index].amount -= 1;
            }
        }
        public List<InventoryItem> GetItemList()
        {
            return inventoryItems;
        }

        public void SortList(int removedIndex)
        {
            List<InventoryItem> sortedList = new List<InventoryItem>();
            foreach (InventoryItem item in inventoryItems)
            {
                sortedList.Add(item);
            }
            inventoryItems = sortedList;
        }
    }
}

