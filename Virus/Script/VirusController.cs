using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{
    float virusDestoryTime = 30.0f;
    public VirusGenerator currentGen;
    bool isCleansing = false;
    bool c9 = false;

    void Start()
    {
        currentGen.exist = true;
        Debug.Log("바이러스 나타남" + currentGen.exist);
    }

    void Update()
    {
        bool theEnd = CanvasControl.preProcessingEnd;

        if (!theEnd)
        {
            /*Destroy(gameObject);*/
        }
        else
        {
            Destroy(gameObject, virusDestoryTime);
        }

        if (GameManager.isBattle == false)
        {
            c9 = true;
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Cleanser")
        {
            GameManager.cleaningVirus++;
            isCleansing = true;
            int tmpMoney = Random.Range(1, 4) * 100;
            if (GameManager.moneyNum + tmpMoney <= 999999 && !c9 && !ReloadBtn.c11) GameManager.moneyNum += tmpMoney;
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        currentGen.exist = false;
        currentGen.delta = 0;
        if (!isCleansing && !c9 && !ReloadBtn.c11) GameManager.health--;
        c9 = false;
    }
}
