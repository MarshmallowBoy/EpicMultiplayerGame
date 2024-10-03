using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemiesToSpawn;
    [Space] 
    float timer;
    float _timer;
    public float timeToSpawn = 30;

    void Update()
    {
        timer += Time.deltaTime;
        _timer += Time.deltaTime;
        if(timer >= timeToSpawn)
        {
            for (int i = Random.Range(0, enemiesToSpawn.Length); i < enemiesToSpawn.Length; i++)
            {
                if (_timer >= 3)
                {
                    DoSpawn();
                }
            }
            timer = 0;
        }
    }

    void DoSpawn()
    {
        Instantiate(enemiesToSpawn[Random.Range(1, enemiesToSpawn.Length)]);
        Debug.Log("Spawned an Enemy");
        _timer = 0;
    }
}