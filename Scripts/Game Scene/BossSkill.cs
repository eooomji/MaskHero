using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill : MonoBehaviour
{
    public static bool playAura = true;
    public ParticleSystem particleObject;

    Rigidbody rigid;
    BoxCollider boxCollider;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();

        particleObject.Stop();
        StartCoroutine(RainDrop());
    }

    IEnumerator RainDrop()
    {
        yield return new WaitForSeconds(0.1f);
        particleObject.Play();
        playAura = true;
        yield return new WaitForSeconds(300f);
        particleObject.Stop();
        playAura = false;

        StartCoroutine(RainDrop());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer==6 && playAura== true)
        {
            other.gameObject.layer = 7;
            GameManager.countMasking--;
        }
    }
}
