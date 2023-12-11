using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    [SerializeField] private float pushForce = 1;
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody _Rig = hit.collider.attachedRigidbody;
        if(_Rig != null){
            Vector3 dir = hit.gameObject.transform.position - transform.position;
            dir.y = 0;
            dir.z = 0;
            dir.Normalize();

            _Rig.AddForceAtPosition(dir*pushForce , transform.position , ForceMode.Impulse);
        }
    }
}
