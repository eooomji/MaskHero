using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int moneyNum = 50000;
    public static int sprayNum = 50; // default : 50
    public static int maskNum = 50; // default : 50
    public static int health = 50; // default : 50
    public static int countMasking = 0;
    public static int cleaningVirus = 0;
    public static int stage = 1;

    public static string UserPlayTime;
    public static string StageTxtS;

    public GameObject BoyPlayer;
    public GameObject GirlPlayer;

    public GameObject Mask01;
    public GameObject Mask02;
    public GameObject Mask03;

    public float playTime;

    public Text moneyTxt;
    public Text sprayTxt;
    public Text maskTxt;

    public Text IngMaskTxt;
    public Text IngSprayTxt;

    public Text stageTxt;
    public Text playTimeTxt;

    public GameObject SuccessPanel;

    public AudioSource bgmA;
    // public AudioSource rankBtnA;

    public RectTransform healthGroup;
    public RectTransform healthBar;

    public int playerMaxHealth = 50;

    bool isEnd;
    bool c8 = false;
    bool c12 = false;
    public static bool isBattle;

    void Start()
    {
        // test용
        // Debug.LogError(" 1: " + MaskS.MaskNum[1] + " 2: " + MaskS.MaskNum[2] + " 3: " + MaskS.MaskNum[3]);
        // Debug.LogError("1 : " + PlayerS.PlayerSex[1] + "2 : " + PlayerS.PlayerSex[2]);
        // Debug.LogError(ResultNameInput.nickname); // 닉네임~~

        if(PlayerS.PlayerSex[1] == 1)
        {
            BoyPlayer.SetActive(true);
            GirlPlayer.SetActive(false);
        }
        else
        {
            BoyPlayer.SetActive(false);
            GirlPlayer.SetActive(true);
        }

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
    }

    void Update()
    {
        isEnd = CanvasControl.preProcessingEnd;
        if (isEnd && c8 == false) {
            bgmA.Play();
            StageStart();
            c8 = true;
        }
        StartCoroutine(doingBattle());
        if (isEnd && c12 == false)
        {
            playTime += Time.deltaTime; // 인식 완 --> 카운트다운 시작
        }
    }


    void GameClear()
    {
        SuccessPanel.SetActive(true);
        c12 = true;
        bgmA.Stop();
        Player.c10 = false;
    }
    IEnumerator doingBattle()
    {
        yield return new WaitForSeconds(0.1f);
        if (stage == 1 && countMasking >= 1 && cleaningVirus >= 1) StageEnd();
        else if (stage == 2 && countMasking >= 1 && cleaningVirus >= 1) StageEnd();
        else if (stage == 3 && countMasking >= 1 && cleaningVirus >= 1) StageEnd();
        else if (stage == 4 && countMasking >= 1 && cleaningVirus >= 1) StageEnd();
        else if (stage == 5 && countMasking >= 1 && cleaningVirus >= 1) GameClear();
    }

    public void StageStart()
    {
        isBattle = true;
        Debug.Log(GameManager.isBattle);

    }

    public void StageEnd()
    {
        /* if (PlayerS.PlayerSex[1] == 1)
         {
             BoyPlayer.transform.position = Vector3.
         }
         else GirlPlayer.transform.position = Vector3.up * (-0.68f);*/

        isBattle = false;
        Debug.Log(GameManager.isBattle);
        countMasking = 0;
        cleaningVirus = 0;
        stage++;
        Invoke("StageStart", 0.5f);
    }

    void LateUpdate()
    {

        if (moneyNum >= 1000)
        {
            string m = moneyNum.ToString();
            int up = moneyNum / 1000;
            int down;
            if (m.Length == 6) down = 3;
            else if (m.Length == 5) down = 2;
            else down = 1;

            /*if (m[down] == '0') down = 0;
            else down = 5;*/
            down = Convert.ToInt32(m[down] - '0');

            moneyTxt.text = up + "," + down + "00원";
        }
        else moneyTxt.text = moneyNum + "원";

        sprayTxt.text = "x " + sprayNum;
        maskTxt.text = "x " + maskNum;

        IngMaskTxt.text = countMasking + "개";
        IngSprayTxt.text = cleaningVirus + "개";

        stageTxt.text = "STAGE " + stage;

        int hour = (int)playTime / 3600;
        int min = (int)((playTime - hour * 3600) / 60);
        int sec = (int)(playTime % 60);

        playTimeTxt.text = string.Format("{0:00}", hour) + " : " + string.Format("{0:00}", min) + " : " + string.Format("{0:00}", sec);
        UserPlayTime = playTimeTxt.text.ToString();

        /*Debug.Log("현재 체력 : " + health);
        Debug.Log("마스크 씌운 횟수 : " + countMasking);
        Debug.Log("바이러스 퇴치 횟수 : " + cleaningVirus);*/

        if (health > 0) healthBar.localScale = new Vector3((float)health / 50, 1, 1);

        if (health <= 0)
        {
            StageTxtS = stageTxt.text.ToString();
            SceneManager.LoadScene(6);
        }
    }
}
