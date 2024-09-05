using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 5;
    public PlayerStats stats;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(stats == null)
            {
                stats = other.GetComponent<PlayerStats>();
            }
            stats.TakeDamage(damage);
        }
    }
}