using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInstructRitesh : MonoBehaviour
{
    [SerializeField] private Behaviour instructionCanvs;
    private bool isDisabled = false;

    void Update()
    {
        if(!isDisabled && instructionCanvs.enabled){
            if(Input.GetButtonDown("SwitchCam") || Input.GetKeyDown(KeyCode.Escape)){
                instructionCanvs.enabled = false;
                isDisabled = true;
                Time.timeScale = 1f;
            }
            else{
                Time.timeScale = 0f;
            }
        }
    }
}
