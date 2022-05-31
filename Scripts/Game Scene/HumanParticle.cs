using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanParticle : MonoBehaviour
{
    public ParticleSystem particleObject;

    void Update()
    {
        if (this.gameObject.layer == 6)
        {
            particleObject.Stop();
        }
    }

}

