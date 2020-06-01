using System.Collections;
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
    void Start()
    {
        enemyhealth = 2;
        agent = GetComponent<NavMeshAgent>();
        attackStatus = false;
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
                    Debug.Log(enemyhealth);
                    WeaponScript.hashit = false;
                }
                else if (enemyhealth == 0)
                {
                    Destroy(this.gameObject);
                    WeaponScript.hashit = false;
                }
            }
        }
        if (other.gameObject.CompareTag("player"))
        {
            attackStatus = true;
            PlayerScript.playerHealth--;                                              //Ziehe bei Kontakt spieler ein HP ab und setze speed auf 0
            agent.speed = 0.0f;
            Debug.Log(attackStatus);
            Debug.Log("Spieler hat " + PlayerScript.playerHealth + " HP");
        }
    }
}
