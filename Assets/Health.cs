using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100;
    public Animator animator;
    public Character character;
    public Animator anim2;
    void Update()
    {
        animator.SetFloat("Health", health);
        if (health <= 0)
        {
            character.enabled = false;
            StartCoroutine(Respawn());
            
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3);
        anim2.Play("Fade");
        yield return new WaitForSeconds(1);
        transform.position = new Vector3(192.5f, 100f, 276.35f);
        character.enabled = true;
        health = 100;
        
    }
}
