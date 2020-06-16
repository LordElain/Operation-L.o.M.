using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            if(collision.gameObject.transform.position.y > this.gameObject.transform.position.y)
            {
                rb.freezeRotation = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            rb.freezeRotation = false;
        }
    }

}
