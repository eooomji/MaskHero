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
        GameManager.moneyNum = 50000;
        GameManager.sprayNum = 50;
        GameManager.maskNum = 50;
        GameManager.health = 50;
        GameManager.stage = 1;
    }
}
