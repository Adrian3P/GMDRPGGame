using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Control;
using RPG.Core;

public class UseItem : MonoBehaviour
{
    Health health;

    public void HealUp(int heal)
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetHealth();
        health.Heal(heal);
    }
}
