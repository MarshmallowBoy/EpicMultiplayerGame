using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnTrigger : MonoBehaviour
{
    [SerializeField] SaveSystem ss;
    public int SceneIndex = 0;
    private void Awake()
    {
        ss = GameObject.Find("Game Controller").GetComponent<SaveSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ss.Save();
            SceneManager.LoadScene(SceneIndex);
        }
    }
}
