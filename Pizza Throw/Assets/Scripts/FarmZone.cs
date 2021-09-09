using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmZone : MonoBehaviour
{
    //Properties...
    private float maxHealth = 100.0f; //Max health of farm zone...
    private float health = 100.0f; //Current health of zone...
    private float damage = 20.0f; //Damage inflicted on the zone...
    public Image healthBarMask; //farm zone health bar...
    public static FarmZone farmZone;
    // Start is called before the first frame update
    void Start()
    {
        healthBarMask.fillAmount = health / maxHealth; //Set a value to the fill amount of the health bar...
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Animal"))//Compare the other collider tag...
        {
            Debug.Log("Animal has entered the farm zone!");
            CalculateHealth();
        }
    }

    private void CalculateHealth()
    {
        health -= damage; //Inflict damange on the health...
        healthBarMask.fillAmount = health / maxHealth; //Set the new fill amount for the health bar...
        if (health <= 0) 
        {
            healthBarMask.fillAmount = 0.0f; //Set fill amount of health bar to zero...
            GameManager.gameManager.gameIsCompleted = true; //game is complete to true...
            GameManager.gameManager.ResultComment(); //Call result comment function from GameManager script...
        }
    }
}
