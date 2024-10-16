using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowGold : MonoBehaviour
{
    public PlayerStats player;
    public TextMeshProUGUI gold;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
    }

    void Update()
    {
        gold.text = $"Current Gold: {player.Gold}";        
    }
}
