using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Crouch : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animatorComp.SetTrigger("Crouch");
        }
        else
        {
            animatorComp.SetTrigger("Idle");
        }
    }
}

