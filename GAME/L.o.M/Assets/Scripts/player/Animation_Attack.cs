using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Attack : MonoBehaviour
{
    private Animator animatorComp = null;
    public bool hashit = false;
    public bool canhit = false;
    AudioSource audioData;
    public AudioClip Attack;
    // Start is called before the first frame update
    void Start()
    {
        animatorComp = GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            canhit = true;
            hashit = true;
            animatorComp.SetTrigger("Hit");
            audioData.PlayOneShot(Attack,0.3f);
        }
    }
}
