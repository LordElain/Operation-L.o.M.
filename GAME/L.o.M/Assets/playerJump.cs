using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//make sure you save the script as "playerJump"
public class playerJump : MonoBehaviour
{

    //variables that are set
    Rigidbody player; //allows what rigidbody the player will be
    private float jumpForce = 10f; //how much force you want when jumping
    private bool onGround; //allows the functions to determine whether player is on the ground or not


    //the first thing to happen at runtime
    void Start()
    {
        //grabs the Rigidbody from the player
        player = GetComponent<Rigidbody>();
        //says that the player is on the ground at runtime
        onGround = true;
    }

    //checks every frome if the parameters are met to start the function
    void Update()
    {
        //checks if the player is on the ground when the "Jump" button is pressed
        if (Input.GetButton("Jump") && onGround == true)
        {
            //adds force to player on the y axis by using the flaot set for the variable jumpForce. Causes the player to jump
            player.velocity = new Vector3(0f, jumpForce, 0f);
            //says the player is no longer on the ground
            onGround = false;
        }
    }

    //checks if player has hit a collider
    void OnCollisionEnter(Collision other)
    {
        //checks if collider is tagged "ground"
        if (other.gameObject.CompareTag("ground"))
        {
            //if the collider is tagged "ground", sets onGround boolean to true
            onGround = true;
        }
    }
}
