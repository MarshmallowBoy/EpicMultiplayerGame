using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveSystem : MonoBehaviour
{ 
    private PlayerStats pStats;
    private EnemyStats enemy;

    private static readonly string keyWord = "soggysufferingsheep";
    private string file;
    private void Start()
    {
        Debug.Log(Application.persistentDataPath);
    }
    private void Awake()
    {
        if(CompareTag("Player"))
        {
            pStats = GetComponent<PlayerStats>();

        }
        else if(CompareTag("Enemy"))
        {
            enemy = GetComponent<EnemyStats>();
        }
        file = $"{Application.persistentDataPath}/{name}.json";
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }

        if(Input.GetKeyDown(KeyCode.Y))
        {
            Delete();
        }
    }

    public void Save()
    {
        SaveData myData = new();

        if(CompareTag("Player"))
        {
            if(TryGetComponent(out pStats))
            {
                myData.currentHealth = pStats.GetPlayerHealth();
                myData.maxHealth = pStats.GetPlayerMaxHealth();
                myData.healthModifier = pStats.GetHealthModifier();
                myData.maxExp = pStats.GetMaxExp();
                myData.currentLevel = pStats.GetCurrentLevel();
                myData.currentExp = pStats.GetCurrentExp();
                myData.gold = pStats.GetGold();
            }
        }

        myData.x = transform.position.x;
        myData.y = transform.position.y;
        myData.z = transform.position.z;

        //Important - DO NOT DELETE
        string myDataString = JsonUtility.ToJson(myData);
        myDataString = EncryptDecryptData(myDataString);
        string file = $"{Application.persistentDataPath}/{name}.json";
        File.WriteAllText(file, myDataString);
        //Debug.Log(Application.persistentDataPath);
    }

    public void Load()
    {
        //Important - DO NOT DELETE
        //string file = $"{Application.persistentDataPath}/{name}.json";
        if(File.Exists(file))
        {
            string jsonData = File.ReadAllText(file);
            jsonData = EncryptDecryptData(jsonData);
            SaveData myData = JsonUtility.FromJson<SaveData>(jsonData);
            transform.position = new Vector3(myData.x, myData.y, myData.z);

            if(CompareTag("Player"))
            {
                if(TryGetComponent(out pStats))
                {
                    pStats.SetCurrentHealth((int)myData.currentHealth);
                    pStats.SetMaxHealth((int)myData.maxHealth);
                    pStats.SetHealthModifier(myData.healthModifier);
                }
                pStats.expToNextLevel = myData.maxExp;
                pStats.currentExp = myData.currentExp;
                pStats.currentLevel = myData.currentLevel;
                pStats.Gold = myData.gold;
            }
        }
    }

    public string EncryptDecryptData(string data)
    {
        string result = string.Empty;

        for(int i = 0; i < data.Length; i++)
        {
            result += (char)(data[i] ^ (keyWord[i % keyWord.Length]));
        }

        return result;
    }

    public void Delete()
    {
        //string file = $"{Application.persistentDataPath}/{name}.json";
        File.Delete(file);
    }
}

[Serializable]
public class SaveData
{
    public float x, y, z;
    public int currentExp, maxExp, currentLevel, currentHealth, maxHealth, healthModifier, gold;
}
