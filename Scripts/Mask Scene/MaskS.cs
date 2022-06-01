using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MaskS : MonoBehaviour
{
    public static int[] MaskNum = { 0, 1, 0, 0 };

    public AudioSource nextBtnA;
    public AudioSource backBtnA;

    int ClickCount = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickCount++;
            if (!IsInvoking("DoubleClick"))
                Invoke("DoubleClick", 1.0f);

        }
        else if (ClickCount == 2)
        {
            CancelInvoke("DoubleClick");
            Application.Quit();
        }
    }

    void DoubleClick()
    {
        ClickCount = 0;
    }

    public void Mask01Btn()
    {
        nextBtnA.Play();
        MaskNum[1] = 1;
        MaskNum[2] = 0;
        MaskNum[3] = 0;

    }

    public void Mask02Btn()
    {
        nextBtnA.Play();
        MaskNum[1] = 0;
        MaskNum[2] = 1;
        MaskNum[3] = 0;

    }

    public void Mask03Btn()
    {
        nextBtnA.Play();
        MaskNum[1] = 0;
        MaskNum[2] = 0;
        MaskNum[3] = 1;

    }

    public void nextClick()
    {
        nextBtnA.Play();
        SceneManager.LoadScene(4);
    }

    public void BackBtn()
    {
        backBtnA.Play();
        SceneManager.LoadScene(2);
    }
}
