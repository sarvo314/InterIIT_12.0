using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] GameObject farView;
    private bool farBool = false;

    //private void Start()
    //{
    //    farView.SetActive(false);  
    //}
    void Update()
    {
        if (Input.GetButtonDown("SwitchCam"))
        {
            if (farBool)
            {
                farView.SetActive(false);
                farBool = false;
            }
            else
            {
                farView.SetActive(true);
                farBool = true;
            }
        }
    }
}
