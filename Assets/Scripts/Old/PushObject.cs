using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    public float pushStrength = 6.0f, speedupStrength = 10.0f;
    private RigidbodyCharacter rc;
    

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        
        if (body == null || body.isKinematic)
        {
            return;
        }

        if (hit.moveDirection.y < -0.3f)
        {
            return;
        }

        pushStrength = rc.Speed;

        Vector3 direction = new Vector3(hit.moveDirection.x, 0, 0);

        body.velocity = direction * pushStrength;
    }

    void Awake()
    {
        GameObject ratte = this.gameObject;
        // GameObject ratte = GameObject.Find("Ratte");
        rc = ratte.GetComponent<RigidbodyCharacter>();
        
    }
}
