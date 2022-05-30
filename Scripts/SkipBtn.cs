using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipBtn : MonoBehaviour
{

    public float playTime;

    public GameObject Skipbutton;

    public AudioSource skipBtnA;

    void Update()
    {
        playTime += Time.deltaTime;
        if (playTime > 5)
        {
            Skipbutton.SetActive(true);
        }
    }
    public void SkipClick()
    {
        skipBtnA.Play();
        SceneManager.LoadScene(2);
    }
}
