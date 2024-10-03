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
    public int eFinalHealth;
    public int eBaseHealth = 10;
    private PlayerStats pstats;
    [SerializeField] private int entityID = 0;

    public EnemyType myType;

    void Awake()
    {
        pstats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        
        if (rollLevel == true)
        {
            enemyLevel = Random.Range(1, 50);
            rollLevel = false;
            rollHealth = true;
        }
        if (rollDamage == true)
        {
            damageRoll = Random.Range(dR1, dR2);
            rollDamage = false;
        }
        if (rollHealth == true)
        {
            healthRoll = Random.Range(hR1, hR2);
            rollHealth = false;
        }

        EnemyStatCalculation();

        if(isRoyal == true) 
        { 
            RoyaltyCalculation();
        }
    }

    private void EnemyStatCalculation()
    {
        if (myType == EnemyType.Slime)
        {
            eFinalDamage = damageRoll + (2 * enemyLevel);
            eFinalHealth = eBaseHealth + (healthRoll * enemyLevel);
        }
        else if (myType == EnemyType.Blob)
        {
            eFinalDamage = damageRoll + (5 * (enemyLevel + 3));
            eFinalHealth = eBaseHealth + (healthRoll * (enemyLevel + 2));
        }
    }

    private void BossCalculation()
    {
        enemyLevel = 55;
        EnemyStatCalculation();
    }

    private void RoyaltyCalculation()
    {
        if (entityID != 20 || entityID != 21 || entityID != 42) { isRoyal = false; return; }
        if (damageRoll <= 2) { Debug.Log("damageRoll is too low for " + entityID + ", " + damageRoll + ", rerolling..."); damageRoll = Random.Range(3, 15); Debug.Log(entityID + " new roll, " + damageRoll); }
        if (healthRoll <= 9) { Debug.Log("healthRoll is too low for " + entityID + ", " + healthRoll + ", rerolling..."); healthRoll = Random.Range(15, 35); Debug.Log(entityID + " new roll, " + healthRoll); }
        if (enemyLevel <= 34 && entityID == 20 || entityID == 21) { Debug.Log("levelRoll is too low for " + entityID + ", " + enemyLevel + ", rerolling..."); enemyLevel = Random.Range(35, 50); Debug.Log(entityID + " new roll, " + enemyLevel); }
        EnemyStatCalculation();
        if (entityID == 20 || entityID == 21)
        {
            eFinalDamage *= (damageRoll / 2);
            eFinalHealth *= (healthRoll / 2);
        }
        else if (entityID == 42)
        {
            eFinalDamage *= 2;
            eFinalHealth *= 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            pstats.TakeDamage(eFinalDamage);
        }

        if(other.tag == "Bullet")
        {
            eFinalHealth -= pstats.playerDamage;
            Destroy(other.gameObject);
        }
        
        if(eFinalHealth >= 0)
        {
            Drops();
            Destroy(gameObject);
        }
    }

    private void Drops()
    {
        if(myType == EnemyType.Slime)
        {
            //drops 1-6 slime goo with a 1.5% chance to drop a slime Gem and a 15% for Slime Soda

        }
        else if(myType == EnemyType.Blob)
        {
            //drops 0-3 Blob fertalizer with a 10% chance for 1-3 slime goo

        }
    }
}