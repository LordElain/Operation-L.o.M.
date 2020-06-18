using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations_Movement : MonoBehaviour
{
    private Animator animatorComp = null;
    public GameObject Spieler;
    AudioSource audioData;
    public AudioClip Walk;
    // Start is called before the first frame update
    void Start()
    {
        animatorComp = GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //RUN
        if (Input.GetKeyDown(KeyCode.W))
        {
            animatorComp.SetTrigger("Run");
            animatorComp.SetBool("Idle_Status", false);
            audioData.PlayOneShot(Walk, 0.3f);


        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animatorComp.SetBool("Crouch_Status", false);
            animatorComp.SetBool("Idle_Status", true);
        }
        //CROUCH
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animatorComp.SetBool("Crouch_Status", true);
            animatorComp.SetBool("Idle_Status", false);
            animatorComp.SetTrigger("Crouch");
            
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            animatorComp.SetBool("Crouch_Status", false);
            animatorComp.SetBool("Idle_Status", true);
        }





    }
}
