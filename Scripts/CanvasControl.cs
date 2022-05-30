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

        if (Ts) // �νĿ� �������� ��
        {
                if (!countEnd && !realEnd) // �ν� ���� �� ������ �ٺ��� ī��Ʈ ���� 1ȸ
                {
                    StartCoroutine("CountDown");
                }
                else if(!realEnd)
                {
                    preProcessingEnd = true;
                }
        }
        else // �ν� ���� ��
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
