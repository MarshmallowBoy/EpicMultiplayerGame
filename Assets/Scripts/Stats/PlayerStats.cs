using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int hMod = 0;
    public int playerHealth = 25;
    public int playerMaxHealth = 25;
    public int playerBaseHealth = 25;
    [SerializeField] int playerLvl1Health = 25;
    [SerializeField] int playerHealthPerLevel = 10;
    [Space]
    public int currentLevel = 1;
    public int playerMaxLevel = 50;
    [Space]
    public int currentExp = 0;
    public int expToNextLevel = 225;
    [Space]
    public int dMod = 0;
    public int playerDamage = 1;
    [SerializeField] int baseDamage = 3;
    [Space]
    public int resistance = 0;
    public int Gold = 0;
    protected bool lvlCheck = true;

    public Animator animator;
    public Character character;
    public Animator anim2;
    public Vector3 Spawningpoint;
    TrainerButtons statUp;

    //EXP req from 1-50(1275) 95850 (was 164150 (was 170150 (was 446250)))

    private void Awake()
    {
        if(GameObject.FindWithTag("Trainer") != null)
        {
            statUp = GameObject.FindWithTag("Trainer").GetComponent<TrainerButtons>();
        }
        animator = GetComponent<Animator>();
        character = GetComponent<Character>();
        anim2 = GameObject.Find("Canvas").GetComponent<Animator>();
        Spawningpoint = transform.position;
    }

    private void Update()
    {
        if(currentExp >= expToNextLevel) { lvlCheck = true; if(lvlCheck == true) { CanLevelUp(); } }
        if(playerHealth > playerMaxHealth) { playerHealth = playerMaxHealth; }
        if(playerMaxHealth != playerBaseHealth + (playerHealthPerLevel * (currentLevel - 1)) + hMod || playerDamage != baseDamage + dMod)
        {
            StatUpdate();
        }
        animator.SetFloat("Health", playerHealth);

        if (currentLevel >= playerMaxLevel)
        {
            expToNextLevel = 20000000;
        }
        else if (currentLevel != playerMaxLevel)
        {
            ExpCurve();
        }

        if(playerHealth <= 0)
        {
            character.enabled = false;
            StartCoroutine(Respawn());
        }
    }

    public void IncreaseResistance(int rAmount)
    {
        resistance += rAmount;
        Gold -= statUp.resistanceCost;
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
        amount -= resistance;
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
        playerMaxHealth = playerBaseHealth + hMod;
        baseDamage = currentLevel;
        playerDamage = baseDamage + dMod;
    }

    void LevelUpHeal()
    {
        playerHealth = playerMaxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        if(other.tag == "Slime")
        {
            EnemyStats eStats;
            eStats = other.GetComponent<EnemyStats>();
            playerHealth -= eStats.eFinalDamage - resistance;
            Debug.Log($"did {eStats.eFinalDamage - resistance} damage");
        }
        else if(other.tag == "Blob")
        {
            EnemyStats eStats;
            eStats = other.GetComponent<EnemyStats>();
            for (int i = 0; i < 3; i++)
            {
                playerHealth -= (eStats.eFinalDamage/3)  - (resistance/3);
            }  
            Debug.Log($"did {eStats.eFinalDamage - resistance} damage");
        }
        */
    }

    public int GetHealthModifier()
    {
        return hMod;
    }
    public int GetResistance()
    {
        return resistance;
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    public int GetPlayerMaxHealth()
    {
        return playerMaxHealth;
    }

    public int GetMaxExp()
    {
        return expToNextLevel;
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public int GetCurrentExp()
    {
        return currentExp;
    }

    public int GetGold()
    {
        return Gold;
    }

    public void SetMaxHealth(int health)
    {
        playerMaxHealth = health;
    }

    public void SetCurrentHealth(int health)
    {
        playerHealth = health;
    }

    public void SetHealthModifier(int health)
    {
        hMod = health;
    }
    


    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3);
        anim2.Play("Fade");
        yield return new WaitForSeconds(1);
        //transform.position = new Vector3(192.5f, 100f, 276.35f);
        transform.position = Spawningpoint;
        character.enabled = true;
        playerHealth = playerMaxHealth;
    }
}