using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartS : MonoBehaviour
{
    public GameObject HelpImg;

    public AudioSource startBtnA;
    public AudioSource helpBtnA;

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

    public void StartClick()
    {
        startBtnA.Play();
        SceneManager.LoadScene(1);
    }

    public void HelpClick()
    {
        helpBtnA.Play();

        if (HelpImg.activeSelf == false) HelpImg.SetActive(true);
        else if (HelpImg.activeSelf == true) HelpImg.SetActive(false);
    }
}
