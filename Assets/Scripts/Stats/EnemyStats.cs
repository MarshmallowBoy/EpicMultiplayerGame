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
    [Space]
    public int eFinalDamage;
    public int eFinalHealth;
    private PlayerStats pstats;

    public EnemyType myType;

    void Awake()
    {
        if(rollLevel == true)
        {
            enemyLevel = Random.Range(1, 50);
        }
        if(rollDamage == true)
        {
            damageRoll = Random.Range(dR1, dR2);
        }
        if(rollHealth == true)
        {
            healthRoll = Random.Range(hR1, hR2);
        }

        if(myType == EnemyType.Slime)
        {
            eFinalDamage = damageRoll + 2 * enemyLevel;
            eFinalHealth = healthRoll * enemyLevel;
        }
        else if(myType == EnemyType.Blob)
        {
            eFinalDamage = damageRoll + 5 * (enemyLevel + 3);
            eFinalHealth = healthRoll * (enemyLevel + 2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(pstats == null)
            {
                pstats = other.GetComponent<PlayerStats>();
            }
            pstats.TakeDamage(eFinalDamage);
        }
    }



    private void Drops()
    {
        if (myType == EnemyType.Slime)
        {

        }
        else if (myType == EnemyType.Blob)
        {

        }
    }
}
