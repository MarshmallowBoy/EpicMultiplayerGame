using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemiesToSpawn;
    [Space] 
    float timer;
    public float timeToSpawn = 30;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeToSpawn)
        {
            DoSpawn();
        }
    }

    void DoSpawn()
    {
        for (int i = Random.Range(0, enemiesToSpawn.Length); i < enemiesToSpawn.Length; i++)
        {
                Instantiate(enemiesToSpawn[Random.Range(1, enemiesToSpawn.Length)]);
                Debug.Log("Spawned an Enemy");
        }
    }
}