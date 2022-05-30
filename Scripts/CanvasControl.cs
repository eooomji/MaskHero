using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class CanvasControl : MonoBehaviour
{
    public GameObject countDown;

    public Text countDownText;

    bool countEnd = false;
    bool realEnd = false;

    static public bool preProcessingEnd = false;


    public int count;


    // Update is called once per frame
    void Update()
    {
        bool Ts = DefaultObserverEventHandler.TrackingSuccess;

        if (Ts) // 인식에 성공했을 때
        {
                if (!countEnd && !realEnd) // 인식 성공 후 동영상 다보고 카운트 최초 1회
                {
                    StartCoroutine("CountDown");
                }
                else if(!realEnd)
                {
                    preProcessingEnd = true;
                }
        }
        else // 인식 실패 시
        {
            preProcessingEnd = false;
        }
    }

    IEnumerator CountDown()
    {
        realEnd = true;
        count = 3;
        countDown.SetActive(true);
        for (int i = count; i >= 0; i--)
        {
            if (i == 0)
            {
                countDownText.text = string.Format("START!");
            }
            else
            {
                countDownText.text = string.Format(i.ToString());
            }
            yield return new WaitForSeconds(1f);
        }
        countEnd = true;
        realEnd = false;
        countDown.SetActive(false);
        yield return new WaitForSeconds(1f);
    }
}
