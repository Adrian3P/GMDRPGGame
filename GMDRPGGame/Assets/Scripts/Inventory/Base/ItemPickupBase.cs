using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Control;
using RPG.Items;

public class ItemPickupBase : MonoBehaviour
{
    [HideInInspector] public InventorySystem inventory;
    [HideInInspector] public UI_Inventory uiInventory;
    private bool bItemCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (inventory == null)
        {
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetInventorySystem();

        }

        if (uiInventory == null)
        {
            uiInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetUI_Inventory();
        }

        if (!bItemCollected && other.gameObject.tag == "Player")
        {
            addItemToInventory();
            bItemCollected = true;
        }
    }

    public virtual void addItemToInventory()
    {
        Debug.LogError("addItemToInventory method is not overwritten!");        
    }
}
