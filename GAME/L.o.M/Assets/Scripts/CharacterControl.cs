using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float speed = 4.0f;
    private float speedx;
    private float speedz;
    private float translation;
    private float straffe;
    Rigidbody player; //allows what rigidbody the player will be
    public float jumpForce = 10f; //how much force you want when jumping
    private bool onGround; //allows the functions to determine whether player is on the ground or not
    private bool crouching;
    private bool sprinting;
    private bool wasinair;
    private Vector3 posChange;
    public float turnSpeed = 4.0f;
    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 90.0f;
    CapsuleCollider Controller;

    // Use this for initialization
    void Start()
    {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
        //grabs the Rigidbody from the player
        player = GetComponent<Rigidbody>();
        //says that the player is on the ground at runtime
        onGround = true;
        Controller = GetComponent<CapsuleCollider>();
        speedx = speedz = speed;
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)
        if (onGround == true)
        {
            if (!wasinair)
                speedx = speed;
            wasinair = true;
            if (sprinting && crouching)                                             //Sliden soll nur gehen wenn man während des Sprinten croucht
            {
                Sliding();
            }
            if (Input.GetButtonDown("Sprint"))                                      //Sprinten verdoppelt Spielerspeed, sprinting auf true für crouchen
            {
                speedx *= 2.0f;
                speedz *= 2.0f;
                sprinting = true;
            }
            else if (Input.GetButtonUp("Sprint"))                                   //Alle Geschwindigkeiten wieder normalisieren, sprinting für sliden ändern
            {
                speedx = speed;
                speedz = speed;
                sprinting = false;
            }
        }
        else
        {
            if (wasinair)                                                           //Sidestraifing in der Luft verringer, wasinair damit es nur einmal passiert und speed nicht auf 0 geht
            speedx *= 0.3f;
            wasinair = false;
        }
        straffe = Input.GetAxis("Horizontal") * speedx * Time.deltaTime;            //Bewegungsberechnung x-Achse

        translation = Input.GetAxis("Vertical") * speedz * Time.deltaTime;          //Bewegungsberechnung z-Achse

        transform.Translate(straffe, 0, translation);                               //Kombination von beiden Berechnungen um Bewegunng zu erzeugen

        if (Input.GetKeyDown("escape"))
        {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }

        //checks if the player is on the ground when the "Jump" button is pressed
        if (Input.GetButton("Jump") && onGround == true)
        {
            //adds force to player on the y axis by using the flaot set for the variable jumpForce. Causes the player to jump
            player.velocity = new Vector3(0f, jumpForce, 0f);
            //says the player is no longer on the ground
            onGround = false;
        }
                                                                  
        posChange = new Vector3(0f, -0.25f, 0f);                                    //Vektor für Position ändern

        if (Input.GetButtonDown("Crouch"))
        {
            crouching = true;                                                       //Hitbox und Position werden verringert, crouching auf true für sliding später mal
            Controller.height *= 0.5f;
            this.transform.localPosition += posChange;
        }

        if (Input.GetButtonUp("Crouch"))
        {
            Controller.height *= 2;                                                 //Hitbox und Position wieder normal gemacht, crouchng wieder für sliding
            this.transform.localPosition -= posChange;
            crouching = false;
        }

        MouseAiming();
    }

    void MouseAiming()
    {
        // get the mouse inputs
        float y = Input.GetAxis("Mouse X") * turnSpeed;

        // rotate the camera
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + y, 0);
    }

    void OnCollisionEnter(Collision other)
    {
        //checks if collider is tagged "ground"
        if (other.gameObject.CompareTag("ground"))
        {
            //if the collider is tagged "ground", sets onGround boolean to true
            onGround = true;
        }
    }

    void Sliding()
    {
        for (float i = speedx; i < 1; i--)                                          //funktioniert nicht, nur erste Idee für sliding
        {
            straffe = Input.GetAxis("Horizontal") * speedx * Time.deltaTime;

            translation = Input.GetAxis("Vertical") * speedz * Time.deltaTime;

            transform.Translate(straffe, 0, translation);
            speedx--;
            speedz--;
        }
    }

    public void SlowDown()
    {
        speed *= 0.5f;
        speedx = speedz = speed;
    }
}
