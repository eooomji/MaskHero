using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopExitBtn : MonoBehaviour
{
    public GameObject ShopUI;
    public GameObject JoyStick;

    public void Exit()
    {
        ShopUI.SetActive(false);
        JoyStick.SetActive(true);
    }
}
