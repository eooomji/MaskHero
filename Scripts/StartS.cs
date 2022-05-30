using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartS : MonoBehaviour
{
    public GameObject HelpImg;

    public AudioSource startBtnA;
    public AudioSource helpBtnA;

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
