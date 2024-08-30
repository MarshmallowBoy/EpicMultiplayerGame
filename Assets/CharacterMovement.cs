using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Character character;
    public ParticleSystem ParticleSystem;
    public bool Water;
    public void Update()
    {
        if (character.Controller.velocity.magnitude > 0 && Water)
        {
            ParticleSystem.Play();
        }
        else
        {
            ParticleSystem.Stop();
        }
    }
}
