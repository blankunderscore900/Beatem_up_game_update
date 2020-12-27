using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCameraScript : MonoBehaviour
{

    public void Activate()
    {
        GetComponent<Animator>().SetTrigger("Go");
    }


    void ResetCamera()
    {
        FindObjectOfType<CamFollow>().maxXAndY.x = 200;
    }
}
