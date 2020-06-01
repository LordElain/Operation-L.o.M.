using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Animation : MonoBehaviour
{
    private Animator animatorComp = null;
    public GameObject Following;
    public GameObject Attack;
    // Start is called before the first frame update
    void Start()
    {
        animatorComp = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Follow FollowScript = Following.GetComponent<Follow>();
        EnemyControl AttackScript = Attack.GetComponent<EnemyControl>();
        Debug.Log(FollowScript.detectPlayer);
        if (FollowScript.detectPlayer == true)
        {
            animatorComp.SetTrigger("Run");
            animatorComp.SetBool("Idle_Status", false);
            animatorComp.SetBool("Run_Status", true);
        }
       else
        {
            animatorComp.SetBool("Idle_Status", true);
            animatorComp.SetBool("Run_Status", false);
        }

        if (AttackScript.attackStatus == true)
        {
            animatorComp.SetTrigger("Attack");
            animatorComp.SetBool("Idle_Status", false);
        }
        else
        {
            animatorComp.SetBool("Idle_Status", true);
        }
    }
}
