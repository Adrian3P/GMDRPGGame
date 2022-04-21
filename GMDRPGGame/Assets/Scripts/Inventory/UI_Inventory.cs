using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Items 
{
    public class UI_Inventory : MonoBehaviour
    {
        private InventorySystem inventory;
        private Transform itemSlotContainer;
        private Transform itemSlotTemplate;

        private void Awake()
        {
            itemSlotContainer = transform.Find("itemSlotContainer");
            itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        }

        public void SetInventory(InventorySystem inventory)
        {
            this.inventory = inventory;
            itemSlotContainer = transform.Find("itemSlotContainer");
            itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
            RefreshInventoryItems();
        }

        public void RefreshInventoryItems()
        {
            int x = 0;
            float y = 0;
            foreach (InventoryItem item in inventory.GetItemList())
            {
                RectTransform inventoryItemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
                inventoryItemSlotRectTransform.gameObject.SetActive(true);

                inventoryItemSlotRectTransform.anchoredPosition = new Vector2(x , y);
                Image image = inventoryItemSlotRectTransform.Find("Item").GetComponent<Image>();
                image.sprite = item.GetSprite();
                x += 120;
            }
        }
    }
}


