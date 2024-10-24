using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowGold : MonoBehaviour
{
    public PlayerStats player;
    public TextMeshProUGUI gold;

    void Update()
    {
        if(player == null) { player = GameObject.FindWithTag("Player").GetComponent<PlayerStats>(); }
        gold.text = $"Current Gold: {player.Gold}";        
    }
}
