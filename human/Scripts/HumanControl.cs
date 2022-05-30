using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanControl : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        bool theEnd = CanvasControl.preProcessingEnd;

        

        if (GameManager.isBattle == false)
        {
            WayPointMove.c9 = true;
            Destroy(gameObject);
        }
    }
}
