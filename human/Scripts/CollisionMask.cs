using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMask : MonoBehaviour
{
    public GameObject humanMaskPrefab;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "KF94")
        {
            if(gameObject.GetComponent<WayPointMove>().isActive == false)
            {
                gameObject.GetComponent<WayPointMove>().isActive = true;
                GameManager.countMasking++;

                humanMaskPrefab.SetActive(true);
                this.gameObject.layer = 6;
                int tmpMoney = Random.Range(3, 6) * 100;
                if (GameManager.moneyNum + tmpMoney <= 999999 && !WayPointMove.c9 && !ReloadBtn.c11)
                {
                    GameManager.moneyNum += tmpMoney;
                }
            }
        }
    }
}
