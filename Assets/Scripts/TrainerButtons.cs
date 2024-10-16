using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
public class TrainerButtons : MonoBehaviour
{
    PlayerStats playerStats;
    public int healthCost = 5;
    public int hAmountToIncrease = 10;
    public int hCostMax = 100;
    public TextMeshProUGUI hCost;
    [SerializeField] int hCostScaler = 1;
    [Space]
    public int damageCost = 5;
    public int dAmountToIncrease = 2;
    public int dCostMax = 100;
    public TextMeshProUGUI dCost;
    [SerializeField] int dCostScaler = 1;
    [Space]
    public int resistanceCost = 25;
    public int rAmountToIncrease = 1;
    public int rCostMax = 500;
    public TextMeshProUGUI rCost;
    [SerializeField] int rCostScaler = 5;
    [Space]
    public int levelCost = 5000;
    [SerializeField] int lAmountToIncrease = 1;

    private void Awake()
    {
        playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        rCost.text = $"{resistanceCost} Gold";
        hCost.text = $"{healthCost} Gold";
        dCost.text = $"{damageCost} Gold";
    }
    public void ResisanceIncrease()
    {
        if(playerStats.Gold < resistanceCost) { return; }
        else if(playerStats.Gold >= resistanceCost) { playerStats.IncreaseResistance(rAmountToIncrease); /*playerStats.Gold -= resistanceCost;*/ }
        if (resistanceCost < rCostMax) { resistanceCost += rCostScaler; }
        rCost.text = $"{resistanceCost} Gold";
    }
    public void HealthIncrease()
    {
        if(playerStats.Gold < healthCost) { return; }
        else if(playerStats.Gold >= healthCost) { playerStats.IncreaseHealth(hAmountToIncrease); /*playerStats.Gold -= healthCost;*/ }
        if(healthCost < hCostMax) { healthCost += hCostScaler; }
        hCost.text = $"{healthCost} Gold";
    }

    public void DamageIncrease()
    {
        if (playerStats.Gold < damageCost) { return; }
        else if (playerStats.Gold >= damageCost) { playerStats.IncreaseDamage(dAmountToIncrease); /*playerStats.Gold -= damageCost;*/ }
        if (damageCost < dCostMax) { damageCost += dCostScaler; }
        dCost.text = $"{damageCost} Gold";
    }

    public void MaxLevelIncrease()
    {
        if (playerStats.Gold < levelCost) { return; }
        else if (playerStats.Gold >= levelCost) { playerStats.IncreaseMaxLevel(lAmountToIncrease); /*playerStats.Gold -= levelCost;*/ }
    }
}
