using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { Slime, Blob }

public class EnemyStats : MonoBehaviour
{
    [SerializeField] int enemyLevel = 1;
    [Space]
    [SerializeField] int healthRoll;
    [SerializeField] int hR1 = 5;
    [SerializeField] int hR2 = 25;
    [Space]
    [SerializeField] int damageRoll;
    [SerializeField] int dR1 = 1;
    [SerializeField] int dR2 = 10;
    [Space]
    [SerializeField] bool rollLevel = false;
    [SerializeField] bool rollHealth = false;
    [SerializeField] bool rollDamage = false;
    [SerializeField] bool isRoyal = false;
    [SerializeField] bool isBoss = false;
    [Space]
    public int eFinalDamage;
    public int eFinalHealth = 1;
    public int eBaseHealth = 10;
    [SerializeField] private PlayerStats pstats;
    public int entityID = 0;
    [SerializeField] private string entityName = "PH";
    [SerializeField] private string entityType = "PH";
    public InventoryManager inventoryManager;
    public GameObject DeathAnimation;
    public bool Drop = false;

    private void Update()
    {
        if(Drop == true)
        {
            Drop = false;
            Drops();
        }

        if(eFinalHealth <= 0)
        {
            Drops();
            Instantiate(DeathAnimation, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public EnemyType myType;

    private void Awake()
    {
        pstats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        entityType = (myType + " " + entityName);

        if(rollLevel == true)
        {
            enemyLevel = Random.Range(1, 50);
            rollLevel = false;
            rollHealth = true;
        }
        if(rollDamage == true)
        {
            damageRoll = Random.Range(dR1, dR2);
            rollDamage = false;
        }
        if(rollHealth == true)
        {
            healthRoll = Random.Range(hR1, hR2);
            rollHealth = false;
        }

        EnemyStatCalculation();
        
        if(isBoss == true)
        {
            BossCalculation();
        }

        if(isRoyal == true) 
        { 
            RoyaltyCalculation();
        }

        inventoryManager = GameObject.Find("Jeffery").GetComponent<InventoryController>().Inventory.GetComponent<InventoryManager>();
    }

    private void EnemyStatCalculation()
    {
        if(myType == EnemyType.Slime)
        {
            eFinalDamage = damageRoll + (2 * enemyLevel);
            eFinalHealth = eBaseHealth + (healthRoll * enemyLevel);
        }
        else if(myType == EnemyType.Blob)
        {
            eFinalDamage = damageRoll + (5 * (enemyLevel + 3));
            eFinalHealth = eBaseHealth + (healthRoll * (enemyLevel + 2));
        }
    }

    private void BossCalculation()
    {
        enemyLevel = 55;
        EnemyStatCalculation();
        eFinalDamage *= 2;
        eFinalHealth *= 2;
        Debug.Log(entityType + " is a Boss, it's stats have been adjusted accordingly. ID = " + entityID);
    }

    private void RoyaltyCalculation()
    {
        if(entityID != 20 && entityID != 21 && entityID != 42) { Debug.LogWarning(entityType + " is not supposed to be royal, please change this. It is " + "ID# " + entityID); isRoyal = false; return; }
        if(entityID == 20 || entityID == 21 || entityID == 42) { isRoyal = true; }
        if(damageRoll <= 2) { Debug.Log("damageRoll is too low for " + entityType + " at " + damageRoll + ", rerolling..."); damageRoll = Random.Range(3, 15); Debug.Log(entityType + " new damageRoll, " + damageRoll + ", ID = " + entityID); }
        if(healthRoll <= 9) { Debug.Log("healthRoll is too low for " + entityType + " at " + healthRoll + ", rerolling..."); healthRoll = Random.Range(15, 35); Debug.Log(entityType + " new healthRoll, " + healthRoll + ", ID = " + entityID); }
        if(isBoss == true) { enemyLevel = 55; Debug.Log(entityType + " is a Boss. It is ID# " + entityID); }
        else if(enemyLevel <= 34 && entityID == 20 || entityID == 21) { Debug.Log("levelRoll is too low for " + entityType + " at " + enemyLevel + ", rerolling..."); enemyLevel = Random.Range(35, 50); Debug.Log(entityType + " new level, " + enemyLevel + ", ID = " + entityID); }
       
        EnemyStatCalculation();
        
        if(entityID == 20 || entityID == 21)
        {
            eFinalDamage *= (damageRoll / 2);
            eFinalHealth *= (healthRoll / 2);
            if(isBoss == true)
            {
                eFinalDamage *= 2;
                eFinalHealth *= 2;
            }
        }
        else if(entityID == 42)
        {
            eFinalDamage *= 2;
            eFinalHealth *= 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(myType == EnemyType.Slime)
            {
                pstats.TakeDamage(eFinalDamage);
                Debug.Log("Solid");
            }
            else if(myType == EnemyType.Blob)
            {
                for(int i = 0; i < 3; i++)
                {
                    pstats.TakeDamage(eFinalDamage / 3);
                    Debug.Log("DoT");
                }
            }
        }

        if(other.tag == "Bullet")
        {
            eFinalHealth -= pstats.playerDamage;
            Destroy(other.gameObject);
        }
    }

    private void Drops()
    {
        if(myType == EnemyType.Slime)
        {
            Debug.Log("Drops");
            //drops 1-2 slime goo with a 1% chance to drop a slime Gem and a 20% for Slime Soda
            for(int i = 0; i < Random.Range(1,2); i++)
            {
                inventoryManager.GiveItem(2);
            }
            if(Random.Range(1, 5) == 1)
            {
                inventoryManager.GiveItem(4);
            }
            if(Random.Range(1, 100) == 1)
            {
                inventoryManager.GiveItem(3);
            }
        }
        else if(myType == EnemyType.Blob)
        {
            //drops 0-3 Blob fertalizer with a 10% chance for 1 slime goo
            for(int i = 0; i < Random.Range(0, 3); i++)
            { 
                inventoryManager.GiveItem(6);
            }
            if(Random.Range(1, 10) == 1)
            {
                inventoryManager.GiveItem(3);
            }
        }
    }
}