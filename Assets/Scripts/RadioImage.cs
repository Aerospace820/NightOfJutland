using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioImage : MonoBehaviour 
{
    public Material[] materials; // Array of materials to choose from

    private ParticleSystem particleSystemComponent; // Renamed variable

    void Start()
    {
        particleSystemComponent = GetComponent<ParticleSystem>();

        // Ensure there is at least one burst
        if (particleSystemComponent.emission.burstCount > 0)
        {
            // Get the first burst and adjust its parameters
            ParticleSystem.Burst firstBurst = particleSystemComponent.emission.GetBurst(0);
            firstBurst.minCount = 1;
            firstBurst.maxCount = 1;
            firstBurst.cycleCount = 1;
            firstBurst.repeatInterval = 1;

            // Set the adjusted burst back to the ParticleSystem
            particleSystemComponent.emission.SetBurst(0, firstBurst);
        }
    }

    void OnParticleEmit(ParticleSystem.EmitParams emitParams)
    {
        // Get a random material from the array
        Material randomMaterial = materials[Random.Range(0, materials.Length)];

        // Assign the random material to the particle system renderer
        ParticleSystemRenderer particleRenderer = GetComponent<ParticleSystemRenderer>();
        particleRenderer.material = randomMaterial;
    }
}