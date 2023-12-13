using UnityEngine;

public class Instructions : MonoBehaviour
{
    [SerializeField] private GameObject moveInst;
    [SerializeField] private GameObject Finst;
    [SerializeField] private GameObject TelInst;

    void Update()
    {
        if (TeleportSystem.nearPortal)
        {
            moveInst.SetActive(false);
            TelInst.SetActive(true);
        }
        else {
            TelInst.SetActive(false);
            moveInst.SetActive(true);
        }

        if(PauseMenu.isPaused){
            Finst.SetActive(false);
            if (TeleportSystem.nearPortal){
                TelInst.SetActive(false);
            }
            else{
                moveInst.SetActive(false);
            }
        }
        else{
            Finst.SetActive(true);
            if (TeleportSystem.nearPortal){
                TelInst.SetActive(true);
            }
            else{
                moveInst.SetActive(true);
            }
        }
    }
}
