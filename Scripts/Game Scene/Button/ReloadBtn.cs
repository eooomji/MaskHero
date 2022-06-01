using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadBtn : MonoBehaviour
{
    static public bool c11 = false;
    public void Awake()
    {
        c11 = false;
    }

    public void ReloadBtnClick()
    {
        c11 = true;

        SceneManager.LoadScene(4);

        GameManager.cleaningVirus = 0;
        GameManager.countMasking = 0;
        GameManager.moneyNum = 5000;
        GameManager.sprayNum = 30;
        GameManager.maskNum = 30;
        GameManager.health = 20;
        GameManager.stage = 1;
    }
}
