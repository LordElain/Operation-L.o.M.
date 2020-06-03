using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Animation : MonoBehaviour
{
    private Animator animatorComp = null;
    public GameObject Following;
    public GameObject Attacking;
    // Start is called before the first frame update
    void Start()
    {
        animatorComp = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Follow_R FollowScript = Following.GetComponent<Follow_R>();
        EnemyControl AttackScript = Attacking.GetComponent<EnemyControl>();
        //Debug.Log(FollowScript.detectPlayer);
        if (FollowScript.detectPlayer == true)
        {
            animatorComp.SetTrigger("Run");
            animatorComp.SetBool("IdleStatus", false);
            animatorComp.SetBool("RunStatus", true);
        }
       else
        {
            animatorComp.SetBool("IdleStatus", true);
            animatorComp.SetBool("RunStatus", false);
        }

        if (AttackScript.attackStatus == true)
        {
            animatorComp.SetTrigger("Attack");
            animatorComp.SetBool("IdleStatus", false);
        }
        else
        {
            animatorComp.SetBool("IdleStatus", true);
        }
    }
}
