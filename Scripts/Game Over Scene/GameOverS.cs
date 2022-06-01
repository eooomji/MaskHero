using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverS : MonoBehaviour
{
    public Text StageTxt;
    public Text TimeTxt;

    public AudioSource btnA;

    void Start()
    {
        StageTxt.text = GameManager.StageTxtS;
        TimeTxt.text = GameManager.UserPlayTime;
    }

    public void RetryBtnClick()
    {
        btnA.Play();
        SceneManager.LoadScene(2);

        GameManager.cleaningVirus = 0;
        GameManager.countMasking = 0;
        GameManager.moneyNum = 5000;
        GameManager.sprayNum = 30;
        GameManager.maskNum = 30;
        GameManager.health = 20;
        GameManager.stage = 1;
    }

    public void ExitBtnClick()
    {
        btnA.Play();
        Application.Quit();
    }
}
