using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChange : MonoBehaviour
{
    [SerializeField] private Material targetSkybox;

    // Start is called before the first frame update
    private void OnEnable()
    {
        RenderSettings.skybox = targetSkybox;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
