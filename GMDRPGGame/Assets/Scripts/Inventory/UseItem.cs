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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject drop = GameObject.FindGameObjectWithTag("WeaponInHand");
        Weapon weapon = player.GetComponent<Fighter>().GetDefaultWeapon();
        player.GetComponent<Fighter>().EquipWeapon(weapon);


        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;
        float spawnDistance = 1.5f;
        
        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

        GameObject.Instantiate(Resources.Load ("Pickups/Sword Pickup") as GameObject, spawnPos, playerRotation);
        Destroy(drop);
    }

    public void SetSwordToDrop(GameObject swordToDrop)
    {
        drop = swordToDrop;
    }
}
