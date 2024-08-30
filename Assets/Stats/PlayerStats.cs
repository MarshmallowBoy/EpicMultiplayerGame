using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    [SerializeField] int playerHealth = 100;
    [SerializeField] int playerBaseHealth = 100;
    [SerializeField] int playerMaxHealth = 100;
    [SerializeField] int playerHealthPerLevel = 15;

    [SerializeField] int playerMana = 100;
    [SerializeField] int playerBaseMana = 100;
    [SerializeField] int playerMaxMana = 100;
    [SerializeField] int playerManaPerLevel = 12;

    [SerializeField] int currentLevel = 1;
    [SerializeField] int playerMaxLevel = 50;

    [SerializeField] int currentExp = 0;
    [SerializeField] int expToNextLevel = 350;

    [SerializeField] int baseDamage = 1;
    [SerializeField] int playerDamage = 1;

    private void Update()
    {
        CanLevelUp();
        if (playerHealth > playerMaxHealth) { playerHealth = playerMaxHealth; }
        if(playerMana > playerMaxMana) { playerMana = playerMaxMana; }
        baseDamage = currentLevel;
        playerDamage = baseDamage; //Plus gear bonuses
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" || other.tag == "EnemyProjectile")
        {
            other.gameObject.GetComponent<EnemyDamage>();
            TakeDamage(5);
        }
    }

    void TakeDamage(int Damage)
    {
        playerHealth -= Damage;
    }

    void StatUpdate()
    {
        playerMaxHealth = playerBaseHealth + (playerHealthPerLevel * (currentLevel - 1));
        playerMaxMana = playerBaseMana + (playerManaPerLevel * (currentLevel - 1));
    }

    void LevelUpHeal()
    {
        playerHealth = playerMaxHealth;
        playerMana = playerMaxMana;
    }

    void ExpCurve()
    {
        expToNextLevel = 350 * currentLevel;
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