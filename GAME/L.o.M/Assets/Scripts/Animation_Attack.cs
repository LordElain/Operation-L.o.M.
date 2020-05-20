using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Attack : MonoBehaviour
{
    private Animator animatorComp = null;
    public bool hashit = false;
    // Start is called before the first frame update
    void Start()
    {
        animatorComp = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            hashit = true;
            animatorComp.SetTrigger("Hit");
        }
    }
}
