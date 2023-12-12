using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeClick : MonoBehaviour
{
    [SerializeField] private CubeManager cubeManager;
    [SerializeField] private Material defaultMaterial; // Material when not clicked
    [SerializeField] private Material clickedMaterial; // Material when clicked
    public bool isLit = false;

    // Function to change the material of the cube
    public void ChangeMaterial()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer.sharedMaterial == defaultMaterial)
        {
            Debug.Log("Default found");
            GetComponent<Renderer>().material = clickedMaterial; // Change material of the clicked cube
            isLit = true;
        }
        else
        {
            Debug.Log("Lit found");
            GetComponent<Renderer>().material = defaultMaterial;
            isLit = false;
        }
    }

    // Function to reset the material of the cube to default
    public void ResetMaterial()
    {
        GetComponent<Renderer>().material = defaultMaterial; // Reset material of the cube
    }

    private void OnMouseUpAsButton()
    {
        cubeManager.OnCubeClicked(this);
    }
}
