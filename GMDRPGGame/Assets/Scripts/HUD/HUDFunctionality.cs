using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using RPG.Core;
using TMPro;

public class HUDFunctionality : MonoBehaviour
{
    private GameObject player;

    private Slider healthSlider;
    private Slider expSlider;
    private Slider manaSlider;

    private TextMeshProUGUI healthText;
    private TextMeshProUGUI expText;
    private TextMeshProUGUI manaText;

    private float maxHealth;

    void Start(){
        if (player == null)
            player = GameObject.FindWithTag("Player");
        
        if (expSlider == null)
            expSlider = GameObject.FindWithTag("EXPSlider").GetComponent<Slider>();

        if (manaSlider == null)
            manaSlider = GameObject.FindWithTag("ManaSlider").GetComponent<Slider>();

        if (healthSlider == null)
            healthSlider = GameObject.FindWithTag("HPSlider").GetComponent<Slider>();

        if (healthText == null)
            healthText = GameObject.FindWithTag("HPText").GetComponent<TextMeshProUGUI>();;

        if (expText == null)
            expText = GameObject.FindWithTag("EXPText").GetComponent<TextMeshProUGUI>();

        if (manaText == null)
            manaText = GameObject.FindWithTag("ManaText").GetComponent<TextMeshProUGUI>();

        maxHealth = player.GetComponent<Health>().GetMaxHealthPoints();
        healthSlider.maxValue = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        updateHPTextAndSlider();
    }

    void updateHPTextAndSlider(){

        healthSlider.GetComponent<Slider>().value = player.GetComponent<Health>().GetHealthPoints();
        healthText.text = player.GetComponent<Health>().GetHealthPoints().ToString() + "/" + maxHealth;
    }
}
