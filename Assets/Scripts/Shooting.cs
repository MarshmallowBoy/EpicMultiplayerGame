using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject Projectile;
    [SerializeField] GameObject FireSpot;
    PlayerStats player;

    [SerializeField] float ttf = 1f;
    float timer;
    int bulletSpeed = 10;
    int damage;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        damage = player.playerDamage;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.F) && timer >= ttf)
        {
            damage = player.playerDamage;
            //Shoot();
            RayShoot();
            Debug.LogWarning("Fired");
        }
    }

    void Shoot()
    {
        Instantiate(Projectile, FireSpot.transform.position, Quaternion.identity);
        Projectile.GetComponent<Rigidbody>().velocity = 10 * bulletSpeed * Camera.main.transform.forward;
        timer = 0;
    }
    
    void RayShoot()
    {
        Ray shootdir = new(Camera.main.transform.position, Camera.main.transform.forward);

        if(Physics.Raycast(shootdir, out RaycastHit hit) && hit.collider.CompareTag("Enemy"))
        {
            EnemyStats enemy = hit.collider.GetComponentInParent<EnemyStats>();
            //enemy.TakeDamage(damage);
            timer = 0;
            Debug.LogWarning($"{enemy.myType}, {enemy.entityID}, {enemy.entityName}");
        }
        else if(hit.collider.tag != "Enemy")
        {
            Debug.Log(hit.collider.tag);
        }
        Debug.DrawLine(Camera.main.transform.position, hit.point, new Color(0, 0, 1, 1), 10);
    }
}
