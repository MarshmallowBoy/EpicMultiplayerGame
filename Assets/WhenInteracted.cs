using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WhenInteracted : MonoBehaviour
{
    public UnityEvent unityEvent;

    private void Start()
    {
        if (unityEvent == null)
        {
            unityEvent = new UnityEvent();
        }
    }

    public void Interact()
    {
        unityEvent.Invoke();
    }
}
