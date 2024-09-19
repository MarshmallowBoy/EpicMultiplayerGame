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
    [SerializeField] int levelCost = 5000;
    [SerializeField] int lAmountToIncrease = 1;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }
    
    public void HealthIncrease()
    {
        if(playerStats.Gold == 0) { return; }
        else if(playerStats.Gold >= healthCost) { playerStats.IncreaseHealth(hAmountToIncrease); }
    }

    public void DamageIncrease()
    {
        if (playerStats.Gold == 0) { return; }
        else if (playerStats.Gold >= damageCost) { playerStats.IncreaseDamage(dAmountToIncrease); }
    }

    public void MaxLevelIncrease()
    {
        if (playerStats.Gold == 0) { return; }
        else if (playerStats.Gold >= levelCost) { playerStats.IncreaseMaxLevel(lAmountToIncrease); }
    }
}
