using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrainerButtons : MonoBehaviour
{
    PlayerStats playerStats;
    public int healthCost = 5;
    public int hAmountToIncrease = 10;
    [Space]
    public int damageCost = 5;
    public int dAmountToIncrease = 2;
    [Space]
    public int levelCost = 5000;
    [SerializeField] int lAmountToIncrease = 1;

    private void Start()
    {
        playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
    }
    
    public void HealthIncrease()
    {
        if(playerStats.Gold <= healthCost) { return; }
        else if(playerStats.Gold >= healthCost) { playerStats.IncreaseHealth(hAmountToIncrease); }
    }

    public void DamageIncrease()
    {
        if (playerStats.Gold <= damageCost) { return; }
        else if (playerStats.Gold >= damageCost) { playerStats.IncreaseDamage(dAmountToIncrease); }
    }

    public void MaxLevelIncrease()
    {
        if (playerStats.Gold <= levelCost) { return; }
        else if (playerStats.Gold >= levelCost) { playerStats.IncreaseMaxLevel(lAmountToIncrease); }
    }
}
