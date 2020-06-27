﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemyhealth;
    public GameObject Weapon;
    public GameObject player;

    public Transform target;
    NavMeshAgent agent;
    public bool attackStatus = false;
    AudioSource audioData;
    public AudioClip Attack;
    void Start()
    {
        enemyhealth = 2;
        agent = GetComponent<NavMeshAgent>();
        attackStatus = false;
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);
        //Debug.Log("Distanz Spieler zu Gegner= " + dist);
        if (dist > 5)                                                                   //Speed wieder auf normal setzen wenn Spieler weit genug weg 
            agent.speed = 3.5f;
    }

    void OnCollisionEnter(Collision other)
    {
        Animation_Attack WeaponScript = Weapon.GetComponent<Animation_Attack>();
        CharacterControl PlayerScript = player.GetComponent<CharacterControl>();

        if (other.gameObject.CompareTag("weapon"))                                      //Wird nur ausgeführt wenn Gameobject den tag 'Weapon' hat
        {
            if (WeaponScript.canhit)
            {
                if (enemyhealth > 0)
                {
                    if (WeaponScript.hashit)
                        enemyhealth--;
                    Debug.Log("Enemy Health" + enemyhealth);
                    WeaponScript.hashit = false;
                }
                else 
                {
                    Destroy(this.gameObject);
                    WeaponScript.hashit = false;
                }
            }
        }
        if (other.gameObject.CompareTag("player"))
        {
            Debug.Log("Attack Status: " + attackStatus);
            attackStatus = true;
            PlayerScript.playerHealth--;                                              //Ziehe bei Kontakt spieler ein HP ab und setze speed auf 0
            agent.speed = 0.0f;
            //Debug.Log(attackStatus);
            Debug.Log("Spieler hat " + PlayerScript.playerHealth + " HP");
            audioData.PlayOneShot(Attack, 0.3f);
            attackStatus = false;

        }
        else
        {
            attackStatus = false;
            Debug.Log("Attack Status: " + attackStatus);
        }
    }
}
