using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] footsteps;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public AudioClip GetFootstep()
    {
        return footsteps[Random.Range(0, footsteps.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
