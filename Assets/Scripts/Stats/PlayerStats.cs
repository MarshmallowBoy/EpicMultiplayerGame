using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int hMod = 0;
    public int playerHealth = 25;
    [SerializeField] int playerBaseHealth = 25;
    [SerializeField] int playerLvl1Health = 25;
    [SerializeField] int playerMaxHealth = 25;
    [SerializeField] int playerHealthPerLevel = 10;
    [Space]
    [SerializeField] int currentLevel = 1;
    [SerializeField] int playerMaxLevel = 50;
    [Space]
    public int currentExp = 0;
    [SerializeField] int expToNextLevel = 225;
    [Space]
    public int dMod = 0;
    public int playerDamage = 1;
    [SerializeField] int baseDamage = 3;
    [Space]
    public int Gold = 0;
    protected bool lvlCheck = true;

    TrainerButtons statUp;

    //EXP req from 1-50(1275) 95850 (was 164150 (was 170150 (was 446250)))

    private void Update()
    {
        if(currentExp >= expToNextLevel) { lvlCheck = true; if(lvlCheck == true) { CanLevelUp(); } }
        if(playerHealth > playerMaxHealth) { playerHealth = playerMaxHealth; }
        if(playerMaxHealth != playerBaseHealth + (playerHealthPerLevel * (currentLevel - 1)) + hMod || playerDamage != baseDamage + dMod)
        {
            StatUpdate();
        }
        if (currentLevel >= playerMaxLevel)
        {
            expToNextLevel = 20000000;
        }
        else if (currentLevel != playerMaxLevel)
        {
            ExpCurve();
        }
    }

    public void IncreaseHealth(int hAmount)
    {
        hMod += hAmount;
        Gold -= statUp.healthCost;
    }
    
    public void IncreaseDamage(int dAmount)
    {
        dMod += dAmount;
        Gold -= statUp.damageCost;
    }

    public void IncreaseMaxLevel(int lAmount)
    {
        playerMaxLevel += lAmount;
        Gold -= statUp.levelCost;
    }

    public void TakeDamage(int amount)
    {
        playerHealth -= amount;
    }

    void CanLevelUp()
    {
        if(currentLevel < playerMaxLevel && currentExp >= expToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        currentLevel++;
        currentExp -= expToNextLevel;
        StatUpdate();
        LevelUpHeal();
        ExpCurve();
    }

    void ExpCurve()
    {
        expToNextLevel = 225 + (75 * (currentLevel - 1));
    }

    void StatUpdate()
    {
        playerBaseHealth = playerLvl1Health + (playerHealthPerLevel * (currentLevel - 1));
        playerMaxHealth = playerBaseHealth + (playerHealthPerLevel * (currentLevel - 1)) + hMod;
        baseDamage = currentLevel;
        playerDamage = baseDamage + dMod;
    }

    void LevelUpHeal()
    {
        playerHealth = playerMaxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Trainer" && statUp == null)
        {
            statUp = other.GetComponent<TrainerButtons>();
        }
    }
}