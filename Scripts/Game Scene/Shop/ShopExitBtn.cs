using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopExitBtn : MonoBehaviour
{
    public GameObject ShopUI;
    public GameObject JoyStick;
    public GameObject Mask01Btn;
    public GameObject Mask02Btn;
    public GameObject Mask03Btn;
    public GameObject SprayBtn;

    public void Exit()
    {
        ShopUI.SetActive(false);
        EnterShop.InShop = false;
    }
}
