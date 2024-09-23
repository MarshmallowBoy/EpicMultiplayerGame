using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public string enemyType = "PH";
    [SerializeField] int enemyLevel = 1;

    public int damage;
    [SerializeField] int damagePercentBonus = 10;
    public PlayerStats pstats;

    private void Update()
    {
        damage = 1 + 2 * (enemyLevel - 1) * ((damagePercentBonus/100) + 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            pstats = other.GetComponent<PlayerStats>();
            pstats.TakeDamage(damage);
        }
    }
}