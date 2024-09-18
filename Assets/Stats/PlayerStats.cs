using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    [SerializeField] int playerHealth = 25;
    [SerializeField] int playerBaseHealth = 25;
    [SerializeField] int playerLvl1Health = 25;
    [SerializeField] int playerMaxHealth = 25;
    [SerializeField] int playerHealthPerLevel = 10;
    [Space]
    [SerializeField] int playerMana = 5;
    [SerializeField] int playerBaseMana = 5;
    [SerializeField] int playerLvl1Mana = 5;
    [SerializeField] int playerMaxMana = 5;
    [SerializeField] int playerManaPerLevel = 5;
    [Space]
    [SerializeField] int currentLevel = 1;
    [SerializeField] int playerMaxLevel = 50;

    [SerializeField] int currentExp = 0;
    [SerializeField] int expToNextLevel = 225;
    [Space]
    [SerializeField] int baseDamage = 1;
    [SerializeField] int playerDamage = 1;

    //EXP req from 1-50(1275) 95850 (was 164150 (was 170150 (was 446250)))
    private void Update()
    {
        CanLevelUp();
        if(playerHealth > playerMaxHealth) { playerHealth = playerMaxHealth; }
        if(playerMana > playerMaxMana) { playerMana = playerMaxMana; }
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    public void TakeDamage(int amount)
    {
        playerHealth -= amount;
    }

    void StatUpdate()
    {
        playerMaxHealth = playerLvl1Health + (playerHealthPerLevel * (currentLevel - 1));
        playerBaseHealth = playerLvl1Health + (playerHealthPerLevel * (currentLevel - 1));
        playerMaxMana = playerLvl1Mana + (playerManaPerLevel * (currentLevel - 1));
        playerBaseMana = playerLvl1Mana + (playerManaPerLevel * (currentLevel - 1));
        baseDamage = currentLevel;
        playerDamage = baseDamage; //Plus gear bonuses, if any
    }

    void LevelUpHeal()
    {
        playerHealth = playerMaxHealth;
        playerMana = playerMaxMana;
    }

    void ExpCurve()
    {
        expToNextLevel = 225 + (75 * (currentLevel - 1));
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
}