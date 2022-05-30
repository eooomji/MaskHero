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
        SceneManager.LoadScene(4);
    }

    public void ExitBtnClick()
    {
        btnA.Play();
        SceneManager.LoadScene(0);
    }
}
