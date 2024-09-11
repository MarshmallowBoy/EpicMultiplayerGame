using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NpcInformation : MonoBehaviour
{
    
    public string NpcName = "PH";
    [Space]
    public bool canBeInteractedWith = true;
    public bool isAttackableByPlayer = false;
    [Space]
    public int NpcMaxHealth = 100;
    public int NpcDamage = 1;
    public int NpcArmor = 1;

    GameObject homePoint;

    void Start ()
    {
        homePoint = new GameObject("homePoint" + NpcName);
        homePoint.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}