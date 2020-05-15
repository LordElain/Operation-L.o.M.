using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator animatorComp = null;
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
            animatorComp.SetTrigger("Hit");
        }
    }
}
