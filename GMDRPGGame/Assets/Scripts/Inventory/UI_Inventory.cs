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

        private void RefreshInventoryItems()
        {
            int x = 0;
            float y = -88.4f;
            float itemSlotCellSize = 10f;
            foreach (InventoryItem item in inventory.GetItemList())
            {
                RectTransform inventoryItemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
                inventoryItemSlotRectTransform.gameObject.SetActive(true);

                inventoryItemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
                Image image = inventoryItemSlotRectTransform.Find("Item").GetComponent<Image>();
                image.sprite = item.GetSprite();
                x += 12;
            }
        }
    }
}


