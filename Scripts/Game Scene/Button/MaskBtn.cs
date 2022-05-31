using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskBtn : MonoBehaviour
{
    public GameObject MaskPrefab;

    public Transform BoyMaskPos;
    public Transform GirlMaskPos;

    public AudioSource maskBtnA;

    static public bool doThrow;

    public void Click()
    {
        if (GameManager.maskNum > 0)
        {
            maskBtnA.Play();

            doThrow = true;

            if (PlayerS.PlayerSex[1] == 1)
            {
                GameObject mask = Instantiate(MaskPrefab, BoyMaskPos.position, BoyMaskPos.rotation) as GameObject;

                Rigidbody maskRigid = mask.GetComponent<Rigidbody>();

                maskRigid.velocity = BoyMaskPos.forward * 0.5f;

                Destroy(mask, 0.5f); // 마스크가 destroyTime 후 제거

                GameManager.maskNum--;
            }
            else {
                GameObject mask = Instantiate(MaskPrefab, GirlMaskPos.position, GirlMaskPos.rotation) as GameObject;

                Rigidbody maskRigid = mask.GetComponent<Rigidbody>();

                maskRigid.velocity = GirlMaskPos.forward * 0.5f;
                
                Destroy(mask, 0.5f); // 마스크가 destroyTime 후 제거

                GameManager.maskNum--;
            }
        }
    }
}
