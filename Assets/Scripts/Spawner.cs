using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemiesToSpawn;
    private GameObject prefab;
    [Space]
    public bool isActive = true;
    [Space]
    float timer;
    float _timer;
    public float timeToSpawn = 30;

    void Update()
    {
        if(!isActive) { return; }
        prefab = enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)];
        timer += Time.deltaTime;
        _timer += Time.deltaTime;
        if(timer >= timeToSpawn)
        {
            DoSpawn();
            timer = 0;
        }
    }

    void DoSpawn()
    {
        for(int i = Random.Range(0, enemiesToSpawn.Length); i < enemiesToSpawn.Length; i++)
        {
            if(_timer >= 1.5f)
            {
                Instantiate(prefab, transform.position, Quaternion.identity);
                Debug.Log("Spawned an Enemy");
                _timer = 0;
            }
        }
    }
}