using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FrontBtn : MonoBehaviour
{
    public GameObject HelpImg;
    public GameObject MaleBtn;
    public GameObject FemaleBtn;
    public GameObject SexText;
    public GameObject MaleNickNameObject;
    public GameObject FemaleNickNameObject;
    public GameObject MaleEndBtn;
    public GameObject FemaleEndBtn;
    public GameObject Mask1Btn;
    public GameObject Mask2Btn;
    public GameObject Mask3Btn;

    public void HelpBtn()
    {
        if (HelpImg.activeSelf == false)
        {
            HelpImg.SetActive(true);
            Debug.Log("On");
        }
        else if (HelpImg.activeSelf== true)
        {
            HelpImg.SetActive(false);
            Debug.Log("Off");
        }
    }
    public void GameStartBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void MaleSelect()
    {
        FemaleBtn.SetActive(false);
        Debug.Log("MaleSelect");
        SexText.SetActive(false);
        MaleNickNameObject.SetActive(true);
    }

    public void FemaleSelect()
    {
        MaleBtn.SetActive(false);
        Debug.Log("FemaleSelect");
        SexText.SetActive(false);
        FemaleNickNameObject.SetActive(true);
    }
    public void MalesEndBtn()
    {
        SceneManager.LoadScene(2);
    }
    public void FeMalesEndBtn()
    {
        SceneManager.LoadScene(2);
    }
    public void MaskSelectBtn()
    {
        SceneManager.LoadScene(3);
    }
    public void PlayerPrevScene()
    {
        SceneManager.LoadScene(0);
    }
    public void MaskPrevScene()
    {
        SceneManager.LoadScene(1);
    }

}

 
