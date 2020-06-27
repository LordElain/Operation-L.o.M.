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
        EnemyControl AttackScript = Attacking.GetComponent<EnemyControl>();
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
