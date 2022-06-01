using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterShop : MonoBehaviour
{
    public GameObject ShopUI;

    public GameObject Mask01;
    public GameObject Mask02;
    public GameObject Mask03;

    public static bool InShop = false;

    public void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player")
        {
            // Debug.LogError("상점 진입");
            ShopUI.SetActive(true);

            if (MaskS.MaskNum[1] == 1)
            {
                Mask01.SetActive(true);
                Mask02.SetActive(false);
                Mask03.SetActive(false);
            }
            else if (MaskS.MaskNum[2] == 1)
            {
                Mask01.SetActive(false);
                Mask02.SetActive(true);
                Mask03.SetActive(false);
            }
            else
            {
                Mask01.SetActive(false);
                Mask02.SetActive(false);
                Mask03.SetActive(true);
            }
            InShop = true;
        }
    }
}
