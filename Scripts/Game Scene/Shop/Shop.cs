using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public int[] itemPrice;
    public string[] talkData;
    public Text talkText;

    public AudioSource MaskSound;
    public AudioSource SpraySound;
    public void Buy(int idx)
    {
        int price = itemPrice[idx];
        if (price > GameManager.moneyNum)
        {
            StopCoroutine(Talk());
            StartCoroutine(Talk());
            return;
        }

        GameManager.moneyNum -= price;

        if (idx == 0)
        {
            MaskSound.Play();
            GameManager.maskNum++;
        }
        else
        {
            SpraySound.Play();
            GameManager.sprayNum++;
        }

    }

    IEnumerator Talk()
    {
        talkText.text = talkData[1];
        talkText.color = Color.red;
        yield return new WaitForSeconds(2f);
        talkText.text = talkData[0];
        talkText.color = Color.black;
    }
}
