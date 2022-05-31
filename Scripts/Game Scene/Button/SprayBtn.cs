using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayBtn : MonoBehaviour
{
    public GameObject BoySprayParticle;
    public GameObject GirlSprayParticle;

    public AudioSource sprayBtnA;

    static public bool doSpraying;

    public void Particle()
    {
        if (GameManager.sprayNum > 0) {
            sprayBtnA.Play();

            doSpraying = true;

            if (PlayerS.PlayerSex[1] == 1)
            {
                BoySprayParticle.SetActive(true);
                GameManager.sprayNum--;
                Invoke("ActiveFalse", 0.5f);
            }
            else
            {
                GirlSprayParticle.SetActive(true);
                GameManager.sprayNum--;
                Invoke("ActiveFalse", 0.5f);
            }
        }
    }

    void ActiveFalse()
    {
        if(PlayerS.PlayerSex[1] == 1) BoySprayParticle.SetActive(false);
        else GirlSprayParticle.SetActive(false);
    }
}
