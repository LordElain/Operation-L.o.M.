using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Animation : MonoBehaviour
{
    private Animator animatorComp = null;
    public Follow Enemy;
    public EnemyControl Attack;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<Follow>();
        animatorComp = GetComponent<Animator>();
        Attack = GetComponent<EnemyControl>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Enemy.detectPlayer == true)
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

        if (Attack.attackStatus != true)
        {
            animatorComp.SetBool("Idle_Status", true);
        }
        else
        {
            animatorComp.SetTrigger("Attack");
            animatorComp.SetBool("Idle_Status", false);
        }
    }
}
