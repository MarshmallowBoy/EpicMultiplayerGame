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
    public void FixedUpdate()
    {
        slider.value += 0.05f;
        if(slider.value >= 100)
        {
            InventoryManager.Instance.GiveItem(1);
            InventoryManager.Instance.GiveItem(1);
            InventoryManager.Instance.GiveItem(1);
            InventoryManager.Instance.GiveItem(1);
            InventoryManager.Instance.GiveItem(1);
            ParticleSystem.SetActive(false);
            TextThing1.SetActive(false);
            TextThing2.SetActive(true);
            slider.value = 0;
            enabled = false;
        }
    }
}
