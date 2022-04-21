using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Items 
{
    public class InventoryItem
    {
        public enum ItemType
        {
            Sword,
            HealthPotion,
            ManaPotion,
            Coin
        }

        public ItemType itemType;
        public int amount;
        public GameObject itemAsset;

        public Sprite GetSprite()
        {
            switch (itemType)
            {
                default:
                case ItemType.Sword: return ItemAssets.Instance.swordSprite;
                case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite;
                case ItemType.ManaPotion: return ItemAssets.Instance.manaPotionSprite;
                case ItemType.Coin: return ItemAssets.Instance.coinSprite;
            }
        }
    }
}


