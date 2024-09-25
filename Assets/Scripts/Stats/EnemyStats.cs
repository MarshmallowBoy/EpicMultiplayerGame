using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { Slime, Blob }

public class EnemyStats : MonoBehaviour
{
    [SerializeField] int enemyLevel = 1;
    [SerializeField] int healthRoll;
    [SerializeField] int hR1 = 5;
    [SerializeField] int hR2 = 25;

    public int eDamage;
    public int eHealth;
    public PlayerStats pstats;

    public EnemyType myType;

    void Awake()
    {
        healthRoll = Random.Range(hR1, hR2);

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
