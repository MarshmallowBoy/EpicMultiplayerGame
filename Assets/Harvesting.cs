using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Harvesting : MonoBehaviour
{
    public Slider slider;
    public GameObject ParticleSystem;
    public GameObject TextThing1;
    public GameObject TextThing2;
    public int ID;
    public int GiveAmount;
    public void FixedUpdate()
    {
        slider.value += 0.05f;
        if(slider.value >= 100)
        {
            for(int i = 0; i < GiveAmount; i++)
            {
                InventoryManager.Instance.GiveItem(ID);
            }
            ParticleSystem.SetActive(false);
            TextThing1.SetActive(false);
            TextThing2.SetActive(true);
            slider.value = 0;
            enabled = false;
        }
    }
}
