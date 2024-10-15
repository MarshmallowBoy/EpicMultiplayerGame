using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WhenInteracted : MonoBehaviour
{
    public UnityEvent unityEvent;
    public float coolDown = 0;
    float nextTimeToFire = 0;
    private void Start()
    {
        if (unityEvent == null)
        {
            unityEvent = new UnityEvent();
        }
    }

    public void Interact()
    {
        if (nextTimeToFire < Time.time)
        {
            nextTimeToFire = Time.time + coolDown;
            unityEvent.Invoke();
        }
    }
}
