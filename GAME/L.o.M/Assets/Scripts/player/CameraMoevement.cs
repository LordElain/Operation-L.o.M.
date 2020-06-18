using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoevement : MonoBehaviour
{
    Rigidbody rb;
    public GameObject player;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public float turnSpeed = 4.0f;
    public float moveSpeed = 2.0f;

    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 90.0f;
    private float rotX;

    void Update()
    {
        CharacterControl PlayerScript = player.GetComponent<CharacterControl>();
        if(!PlayerScript.alive)
        {
            rb.freezeRotation = true;
        }
        else if(!PlayerScript.gameEnd)
        {
            rb.freezeRotation = true;
        }
        else if (PlayerScript.alive && PlayerScript.gameEnd == false)
        {
            MouseAiming();
        }
    }

    void MouseAiming()
    {
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;

        // clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        // rotate the camera
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y , 0);
    }
}
