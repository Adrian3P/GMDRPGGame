using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Control;
using RPG.Core;
using RPG.Combat;
using static RPG.Items.InventoryItem;

public class UseItem : MonoBehaviour
{
    private Health health;
    private PlayerController player;
    private GameObject drop;

    public void CheckWhatItemToUse(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Sword: UseSword(); break;
            case ItemType.HealthPotion: UseHealthPotion(); break;
            case ItemType.ManaPotion: UseManaPotion(); break;
            case ItemType.Coin: UseCoin(); break;
        }
    }

    private void UseHealthPotion()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetHealth();
        health.Heal(20);
    }
    
    private void UseManaPotion()
    {

    }

    private void UseCoin()
    {

    }

    private void UseSword()
    {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            Weapon weapon = player.GetComponent<Fighter>().GetDefaultWeapon();
            player.GetComponent<Fighter>().EquipWeapon(weapon);
            var a = GameObject.FindGameObjectWithTag("WeaponInHand");
            Transform transform = player.GetComponent<Transform>();
            
            Instantiate(drop, transform.forward * 1 ,Quaternion.identity);
            Destroy(a);
    }

    public void SetSwordToDrop(GameObject swordToDrop)
    {
        drop = swordToDrop;
    }
}
