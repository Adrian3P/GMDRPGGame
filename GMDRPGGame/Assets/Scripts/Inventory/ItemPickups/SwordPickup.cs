using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Control;
using RPG.Items;

namespace RPG.Combat
{
    public class SwordPickup : ItemPickupBase
    {
        [SerializeField] Weapon weapon = null;

        GameObject player;

        void Start(){
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
        }
        public override void addItemToInventory()
        {
            player.GetComponent<Fighter>().EquipWeapon(weapon);
            inventory.AddItem(new InventoryItem { itemType = InventoryItem.ItemType.Sword, amount = 1 });
            uiInventory.RefreshInventoryItems();
            Destroy(this.gameObject);
        }
    }
}
