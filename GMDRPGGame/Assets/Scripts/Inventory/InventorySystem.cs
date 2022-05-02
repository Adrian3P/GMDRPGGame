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
        }

        public void AddItem(InventoryItem item)
        {
            inventoryItems.Add(item);
        }

        public void DeleteItem(int index)
        {
            inventoryItems[index].amount -= 1;

            if (inventoryItems[index].amount <= 0)
            {
                inventoryItems.RemoveAt(index);
            }
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

