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
    [SerializeField] int baseDamage = 1;
    [Space]
    public int Gold = 0;
    protected bool lvlCheck = true;

    //EXP req from 1-50(1275) 95850 (was 164150 (was 170150 (was 446250)))
    private void Update()
    {
        if(currentExp >= expToNextLevel) { lvlCheck = true; if(lvlCheck == true) { CanLevelUp(); } }
        if(playerHealth > playerMaxHealth) { playerHealth = playerMaxHealth; }
    }

    public void IncreaseHealth(int hAmount)
    {
        hMod = hAmount;
    }
    
    public void IncreaseDamage(int dAmount)
    {
        dMod += dAmount;
    }

    public void IncreaseMaxLevel(int lAmount)
    {
        playerMaxLevel += lAmount;
    }

    public void TakeDamage(int amount)
    {
        playerHealth -= amount;
    }

    void CanLevelUp()
    {
        if(currentLevel >= playerMaxLevel)
        {
            expToNextLevel = 2000000000;
        }
        else if(currentLevel < playerMaxLevel && currentExp >= expToNextLevel)
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
        playerMaxHealth = playerLvl1Health + (playerHealthPerLevel * (currentLevel - 1)) + hMod;
        playerBaseHealth = playerLvl1Health + (playerHealthPerLevel * (currentLevel - 1));
        baseDamage = currentLevel;
        playerDamage = baseDamage * (150/100) + dMod;
    }

    void LevelUpHeal()
    {
        playerHealth = playerMaxHealth;
    }
}