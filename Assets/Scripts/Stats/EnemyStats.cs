using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { Slime, Blob }

public class EnemyStats : MonoBehaviour
{
    [SerializeField] int enemyLevel = 1;
    [SerializeField] int healthRoll;

    public int eDamage;
    public int eHealth;
    public PlayerStats pstats;

    public EnemyType myType;

    void Awake()
    {
        healthRoll = Random.Range(5, 25);
        if (myType == EnemyType.Slime)
        {
            eDamage = 1 + 2 * (enemyLevel - 1);
            eHealth = healthRoll * (enemyLevel - 1);
        }
        else if (myType == EnemyType.Blob)
        {
            eDamage = 10 + 2 * (enemyLevel + 3);
            eHealth = healthRoll * (enemyLevel + 2);
        }
        
        int Roll = Random.Range(1, 2);
        if (Roll == 1)
        {
            myType = EnemyType.Slime;
            eHealth += 10;

        }

        else if (Roll == 2)
        {
            myType = EnemyType.Blob;
            eHealth += 50;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pstats = other.GetComponent<PlayerStats>();
            pstats.TakeDamage(eDamage);
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
