using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{
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
    public int playerDamage = 1;
    [SerializeField] int baseDamage = 1;

    protected bool lvlCheck = true;

    //EXP req from 1-50(1275) 95850 (was 164150 (was 170150 (was 446250)))
    private void Update()
    {
        if(currentExp >= expToNextLevel) { lvlCheck = true; if(lvlCheck == true) { CanLevelUp(); } }
        if(playerHealth > playerMaxHealth) { playerHealth = playerMaxHealth; }
    }

    public void TakeDamage(int amount)
    {
        playerHealth -= amount;
    }

    void CanLevelUp()
    {
        if(currentLevel >= playerMaxLevel)
        {
            currentExp = 0;
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
        playerMaxHealth = playerLvl1Health + (playerHealthPerLevel * (currentLevel - 1));
        playerBaseHealth = playerLvl1Health + (playerHealthPerLevel * (currentLevel - 1));
        baseDamage = currentLevel;
        playerDamage = baseDamage * (150/100);
    }

    void LevelUpHeal()
    {
        playerHealth = playerMaxHealth;
    }
}