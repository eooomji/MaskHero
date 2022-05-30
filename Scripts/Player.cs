using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ARCamera;

    public VariableJoystick joy;
    public float speed;

    public GameObject joystick;
    public bool isJoystick;

    Rigidbody rigid;
    Animator anim;
    Vector3 moveVec;

    bool isBorder;
    public float dis;

    static public bool c10 = true;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        if (c10 == false)
        {
            Destroy(gameObject);
        }

        if (MaskBtn.doThrow == true)
        {
            anim.SetTrigger("Throw");

            Invoke("Out", 0f);
        }

        if (SprayBtn.doSpraying == true)
        {
            anim.SetTrigger("Spraying");

            Invoke("Out", 0f);
        }

        isBorder = Physics.Raycast(transform.position, transform.forward, dis, LayerMask.GetMask("Wall"));

        isJoystick = joystick.activeSelf;

        float x = joy.Horizontal;
        float z = joy.Vertical;

        if(isJoystick)
        {
            ARCamera = GameObject.Find("ARCamera");

            if (ARCamera.transform.rotation.eulerAngles.y >= 45.0f && ARCamera.transform.rotation.eulerAngles.y <= 135.0f)
            {
                moveVec = new Vector3(z, 0, -x) * speed * Time.deltaTime;
            }

            if ((ARCamera.transform.rotation.eulerAngles.y >= 0.0f && ARCamera.transform.rotation.eulerAngles.y < 45.0f) || (ARCamera.transform.rotation.eulerAngles.y >= 315.0f && ARCamera.transform.rotation.eulerAngles.y < 360.0f))
            {
                Debug.Log("3");
                moveVec = new Vector3(x, 0, z) * speed * Time.deltaTime;
            }

            if (ARCamera.transform.rotation.eulerAngles.y >= 135.0f && ARCamera.transform.rotation.eulerAngles.y < 225.0f)
            {
                Debug.Log("2");
                moveVec = new Vector3(-x, 0, -z) * speed * Time.deltaTime;
            }

            if (ARCamera.transform.rotation.eulerAngles.y >= 225.0f && ARCamera.transform.rotation.eulerAngles.y < 315.0f)
            {
                Debug.Log("1");
                moveVec = new Vector3(-z, 0, x) * speed * Time.deltaTime;
            }
           

            if (!isBorder)
            {
                rigid.MovePosition(rigid.position + moveVec);
            }          
        }


        anim.SetBool("Walk", moveVec != Vector3.zero);

        if (moveVec.sqrMagnitude == 0)
            return;

        Quaternion dirQuat = Quaternion.LookRotation(moveVec);
        Quaternion moveQuat = Quaternion.Slerp(rigid.rotation, dirQuat, 0.5f);
        rigid.MoveRotation(moveQuat);
    }

    void Out()
    {
        MaskBtn.doThrow = false;
        SprayBtn.doSpraying = false;
    }

    void LateUpdate()
    {
/*        isJoystick = joystick.activeSelf;

        if (isJoystick) {
            anim.GetComponent<Animator>().enabled = true;
            anim.SetBool("Walk", true);
        } 
        else anim.GetComponent<Animator>().enabled = false;*/
    }
}
