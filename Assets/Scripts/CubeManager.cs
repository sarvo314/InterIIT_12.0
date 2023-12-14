using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private CubeClick[] cubes; // Array to hold all the cube objects
    [SerializeField] private GameObject jailDoor;
    [SerializeField] private AudioClip openSound;
    [SerializeField] private Jail_Door_Instruction jailDoorInstruction;
    // Function to handle click on a cube
    public void OnCubeClicked(CubeClick clickedCube)
    {
        // Find the index of the clicked cube in the array
        int index = System.Array.IndexOf(cubes, clickedCube);

        // Define the indices of adjacent cubes in the 3x3 grid
        int upIndex = index - 3;
        int downIndex = index + 3;
        int leftIndex = index - 1;
        int rightIndex = index + 1;

        // Change material of the clicked cube
        clickedCube.ChangeMaterial();

        // Change material of adjacent cubes if they exist
        if (upIndex >= 0 && upIndex < cubes.Length)
            cubes[upIndex].ChangeMaterial();

        if (downIndex >= 0 && downIndex < cubes.Length)
            cubes[downIndex].ChangeMaterial();

        if (leftIndex >= 0 && leftIndex < cubes.Length && leftIndex / 3 == index / 3)
            cubes[leftIndex].ChangeMaterial();

        if (rightIndex >= 0 && rightIndex < cubes.Length && rightIndex / 3 == index / 3)
            cubes[rightIndex].ChangeMaterial();

        // If won, gg
        if (Win())
        {
            jailDoor.SetActive(false);
            AudioManager.Instance.PlayAudio(openSound);
            this.gameObject.SetActive(false);
            Destroy(jailDoorInstruction.gameObject);
        }
    }

    /*
    // Function to reset materials of all cubes (Why tho ChatGPT?)
    public void ResetAllMaterials()
    {
        foreach (var cube in cubes)
        {
            cube.ResetMaterial();
        }
    }
    */

    private bool Win()
    {
        bool isWon = true;
        foreach(var cube in cubes)
        {
            if (!cube.isLit)
            {
                isWon = false; break;
            }
        }
        return isWon;
    }
}