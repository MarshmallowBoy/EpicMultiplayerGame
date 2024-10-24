using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health = 100;
    public Animator animator;
    public Character character;
    public Animator anim2;
    public Vector3 Spawningpoint;

    public void Start()
    {
        Spawningpoint = transform.position;
    }

    void Update()
    {
        anim2.GetComponentInChildren<Slider>().value = health;
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
        //transform.position = new Vector3(192.5f, 100f, 276.35f);
        transform.position = Spawningpoint;
        character.enabled = true;
        health = 100;
    }
}
