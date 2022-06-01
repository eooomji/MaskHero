using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class RankS : MonoBehaviour
{
    public Text Nickname1;
    public Text Nickname2;
    public Text Nickname3;
    public Text Nickname4;
    public Text Nickname5;

    public Text PlayTime1;
    public Text PlayTime2;
    public Text PlayTime3;
    public Text PlayTime4;
    public Text PlayTime5;

    public Text MyNickname;
    public Text MyPlayTime;

    public AudioSource btnA;

    public int[,] intPlayTime = new int[5,3];
    public string[] GameNickname = { "gg", "엄지", "김성원", "남자", "흐흐흐"};
    public string[] GamePlayTime = { "00:02:20", "00:02:33", "00:03:12", "00:04:01", "00:04:46"};
    public int idx = 5;

    void Start()
    {
        idx = 5;
        string userNickname = ResultNameInput.nickname;

        MyNickname.text = userNickname; // 사용자 닉네임 잘 넘어옴
        MyPlayTime.text = GameManager.UserPlayTime; // 사용자 PlayTime 잘 넘어옴

        // user PlayTime slice
        string hh = GameManager.UserPlayTime.Substring(0, 2);
        string mm = GameManager.UserPlayTime.Substring(5, 2);
        string ss = GameManager.UserPlayTime.Substring(10);

        int userHour = Convert.ToInt32(hh);
        int userMin = Convert.ToInt32(mm);
        int userSec = Convert.ToInt32(ss);

        // int userHour = 3; int userMin = 0; int userSec = 2; // test용
        // string userNickname = "엄지"; // test용

        for (int i = 0; i < 5; i++)
        {
            string h = GamePlayTime[i].Substring(0, 2);
            string m = GamePlayTime[i].Substring(3, 2);
            string s = GamePlayTime[i].Substring(6, 2);

            intPlayTime[i, 0] = Convert.ToInt32(h);
            intPlayTime[i, 1] = Convert.ToInt32(m);
            intPlayTime[i, 2] = Convert.ToInt32(s);

            Debug.LogError(" 0 : " + intPlayTime[i, 0] + " 1 : " + intPlayTime[i, 1] + " 2 : " + intPlayTime[i, 2]);
        }

        for (int i = 4; i >= 0; i--)
        {
            if (userMin < intPlayTime[i, 1]) idx = i;
        }

        if(idx < 5)
        {
            for (int i = idx; i >= 0; i--)
            {
                if (userSec < intPlayTime[i, 2]) idx = i;
            }

            if (idx == 4)
            {
                intPlayTime[4, 0] = userHour;
                intPlayTime[4, 1] = userMin;
                intPlayTime[4, 2] = userSec;
                GameNickname[4] = userNickname;
            }
            else if (idx < 4)
            {
                for (int i = 3; i >= idx; i--)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        intPlayTime[i + 1, j] = intPlayTime[i, j];
                    }
                    GameNickname[i + 1] = GameNickname[i];
                }
                intPlayTime[idx, 0] = userHour;
                intPlayTime[idx, 1] = userMin;
                intPlayTime[idx, 2] = userSec;
                GameNickname[idx] = userNickname;
            }
        }
        

        // RankList Show
        Nickname1.text = GameNickname[0];
        Nickname2.text = GameNickname[1];
        Nickname3.text = GameNickname[2];
        Nickname4.text = GameNickname[3];
        Nickname5.text = GameNickname[4];


        PlayTime1.text = string.Format("{0:00}", intPlayTime[0, 0]) + " : " + string.Format("{0:00}", intPlayTime[0, 1]) + " : " + string.Format("{0:00}", intPlayTime[0, 2]);
        PlayTime2.text = string.Format("{0:00}", intPlayTime[1, 0]) + " : " + string.Format("{0:00}", intPlayTime[1, 1]) + " : " + string.Format("{0:00}", intPlayTime[1, 2]);
        PlayTime3.text = string.Format("{0:00}", intPlayTime[2, 0]) + " : " + string.Format("{0:00}", intPlayTime[2, 1]) + " : " + string.Format("{0:00}", intPlayTime[2, 2]);
        PlayTime4.text = string.Format("{0:00}", intPlayTime[3, 0]) + " : " + string.Format("{0:00}", intPlayTime[3, 1]) + " : " + string.Format("{0:00}", intPlayTime[3, 2]);
        PlayTime5.text = string.Format("{0:00}", intPlayTime[4, 0]) + " : " + string.Format("{0:00}", intPlayTime[4, 1]) + " : " + string.Format("{0:00}", intPlayTime[4, 2]);

        // 색 변경 - play 시간만 ~~~~~~~~
        if (idx == 0)
        {
            Nickname1.color = Color.red;
            PlayTime1.color = Color.red;
        }
        else if (idx == 1)
        {
            Nickname2.color = Color.red;
            PlayTime2.color = Color.red;
        }
        else if (idx == 2)
        {
            Nickname3.color = Color.red;
            PlayTime3.color = Color.red;
        }
        else if (idx == 3)
        {
            Nickname4.color = Color.red;
            PlayTime4.color = Color.red;
        }
        else if (idx == 4)
        {
            Nickname5.color = Color.red;
            PlayTime5.color = Color.red;
        }
    }

    public void ExitBtn()
    {
        btnA.Play();

        Application.Quit();
    }

    public void ReTryBtn()
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
        idx = 5;
    }
}
