using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnSecond : MonoBehaviour
{
    public float Seconds;
    void Start()
    {
        Destroy(gameObject, Seconds);
    }

}
