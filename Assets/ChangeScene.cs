using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartNextScene", time);
    }

    void StartNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
