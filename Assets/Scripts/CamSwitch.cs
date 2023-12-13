using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    [SerializeField] private GameObject mainView;
    [SerializeField] private GameObject backView;

    private bool isMainVisible = false;
    void Update()
    {
        if(Input.GetButtonDown("SwitchCam")){
            if (isMainVisible)
            {
                backView.SetActive(true);
                mainView.SetActive(false);
                isMainVisible = false;
            }
            else
            {
                mainView.SetActive(true);
                backView.SetActive(false);
                isMainVisible = true;
            }
        }
    }
}
