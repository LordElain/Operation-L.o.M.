using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;                                                      //SceneManagement benutzen damit szene neu geladen werden kann

public class CharacterControl : MonoBehaviour
{
  
    public float speed = 4.0f;

    public bool moving = false;
    
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
    public bool alive;
    private bool speedchange = true;
    public bool gameEnd;
    
    private Vector3 posChange;
    
    public float turnSpeed = 4.0f;
    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 90.0f;
    private float time;
    
    public int playerMaxHealth = 5;
    public int playerHealth = 5;
    public int score;
    
    private float newstraffe;
    private float newtranslation;
    
    CapsuleCollider Controller;
    
    AudioSource audioData;
    
    public AudioClip Jump;
    public AudioClip Run;

    public Text GameOver;
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
        alive = true;
        audioData = GetComponent<AudioSource>();
        gameEnd = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
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

    void FixedUpdate()
    {
        if (playerHealth > playerMaxHealth)                                             // Wenn Spieler mit 5 HP ein collectible aufhebt geht max HP auf 4, daher muss auch momentane HP auf 4 gehen
            playerHealth = playerMaxHealth;
        if (playerHealth == 0)
            alive = false;
        if (gameEnd)
        {
            GameOver.text = "You Won! Your Score was: " + score + Environment.NewLine + "Your time was " + time;
        }
        else if (!alive)
        {
            GameOver.text = "Game Over!" + Environment.NewLine + "Press 'r' to restart!";
            if (Input.GetKey("r"))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (alive)
        {
            if (onGround == true)
            {
                moving = true;
               
                if (!wasinair)
                    speedx = speed;
                wasinair = true;
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

            if (sprinting && crouching)                                             //Sliden soll nur gehen wenn man während des Sprinten croucht
            {
                if (speedchange)
                {
                    newstraffe = straffe;
                    newtranslation = translation;
                }
                speedchange = false;
                if (newtranslation > 0.001f || newtranslation > 0.001f)
                {
                    newstraffe -= (straffe * 0.4f) * Time.deltaTime;
                    newtranslation -= (translation * 0.4f) * Time.deltaTime;
                    //Debug.Log("If ausgeführt");
                }
                transform.Translate(newstraffe, 0, newtranslation);
                //Debug.Log(newstraffe + " und " + newtranslation);
            }
            else
            {
                transform.Translate(straffe, 0, translation);                   //Kombination von beiden Berechnungen um Bewegunng zu erzeugen
                speedchange = true;
            }
            time = Time.fixedTime;
        }


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
        if (other.gameObject.CompareTag("ground") || other.gameObject.CompareTag("box"))
        {
            //if the collider is tagged "ground", sets onGround boolean to true
            onGround = true;
            if (wasinair == false)
            {
                audioData.PlayOneShot(Jump, 0.5f);
            }
            
        }
    }

    public void SlowDown()
    {
        speed *= 0.8f;
        speedx = speed; 
        speedz = speed;
    }

}
