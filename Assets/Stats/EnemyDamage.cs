using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 5;
    public PlayerStats pstats;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(pstats == null)
            {
                pstats = other.GetComponent<PlayerStats>();
            }
            pstats.TakeDamage(damage);
        }
    }
}