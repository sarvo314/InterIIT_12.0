using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform destination;
    [SerializeField] private float distance = 0.5f;
    [SerializeField] private AudioClip teleportSound;
    
    void Start()
    {
        destination = GameObject.FindGameObjectWithTag("PortalB").GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Ball") && Vector3.Distance(transform.position , other.transform.position) > distance){
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 velocity = new Vector3(rb.velocity.x , rb.velocity.y , rb.velocity.z );
            rb.velocity = Vector3.zero;
            other.transform.position = new Vector3(destination.position.x , destination.position.y , destination.position.z);
            rb.velocity = velocity;
            AudioManager.Instance.PlayAudio(teleportSound);
        }
    }
}
