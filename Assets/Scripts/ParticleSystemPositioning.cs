using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemPositioning : MonoBehaviour
{
    public ParticleSystem ParticleSystem;
    void Update()
    {
        if (ParticleSystem == null)
        {
            return;
        }
        RaycastHit _hit;
        if (Physics.Raycast(transform.position, -transform.up, out _hit, Mathf.Infinity, 4))
        {
            Debug.Log(_hit.point);
            if (_hit.transform.CompareTag("Water"))
            {
                Debug.Log(_hit.point + "Water");
            }

            ParticleSystem.transform.position = _hit.point;
        }
    }
}
