using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerS : MonoBehaviour
{
    public static int[] PlayerSex = { 0, 1, 0 };

    public Text SexText;

    public GameObject MaleBtn;
    public GameObject FemaleBtn;
   
    public GameObject MaleNickNameObject;
    public GameObject FemaleNickNameObject;

    public AudioSource nextBtn;

    public void MaleSelect()
    {
        FemaleBtn.SetActive(false);
        PlayerSex[1] = 1; PlayerSex[2] = 0;
        nextBtn.Play();
        SexText.text = "닉네임을 입력해주세요";
        MaleNickNameObject.SetActive(true);
    }

    public void FemaleSelect()
    {
        MaleBtn.SetActive(false);
        PlayerSex[1] = 0; PlayerSex[2] = 1;
        nextBtn.Play();
        SexText.text = "닉네임을 입력해주세요";
        FemaleNickNameObject.SetActive(true);
    }

}
