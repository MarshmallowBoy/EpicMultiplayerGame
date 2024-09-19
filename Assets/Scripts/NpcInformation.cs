using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NpcInformation : MonoBehaviour
{
    public string NpcName = "PH";
    [Space]
    public bool canBeInteractedWith = true;
    public bool isAttackableByPlayer = false;
    [Space]
    public int NpcMaxHealth = 100;
    public int NpcHealth = 100;
    public int NpcDamage = 1;
    public int NpcArmor = 1;
    [Space]
    public int NpcQuestsGiven = 0;
    public int NpcDialogueOptions = 0;
    [Space]
    GameObject homePoint;
    QuestDatabase quests;

    void Start ()
    {
        quests = GetComponent<QuestDatabase>();
        homePoint = new GameObject(NpcName + "'s" + " Home point");
        homePoint.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        quests.LoadQuests();
        /*
        Debug.Log(homePoint.transform.position);
        Debug.Log(homePoint.name);
        Debug.Log(this.transform.position);
        Debug.Log(this.NpcName);
        Debug.Log(this.NpcQuestsGiven);
        */
    }
}