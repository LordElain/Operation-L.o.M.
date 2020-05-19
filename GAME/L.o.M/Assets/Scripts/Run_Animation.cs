using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_Animation : MonoBehaviour
{
    private Animator animatorComp = null;
    public GameObject Spieler;
    // Start is called before the first frame update
    void Start()
    {
        animatorComp = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            
            CharacterControl Play = Spieler.GetComponent<CharacterControl>();

            
            animatorComp.SetTrigger("Run");
          
                
            



        }
        else
        {
            animatorComp.SetTrigger("Idle");
        }
    }
}
