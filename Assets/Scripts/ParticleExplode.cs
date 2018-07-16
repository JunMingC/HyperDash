using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleExplode : MonoBehaviour
{
    public ParticleSystem particle_system;

    private void Update()
    {
        if (TimeControl.timeHealth > 0)
        {
            if (!particle_system.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}
