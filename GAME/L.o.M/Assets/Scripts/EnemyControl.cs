using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemyhealth;
    public GameObject Weapon;
    void Start()
    {
        enemyhealth = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        Animation_Attack WeaponScript = Weapon.GetComponent<Animation_Attack>();
        if (other.gameObject.CompareTag("weapon"))
        {
            if (enemyhealth > 0)
            {
                if (WeaponScript.hashit)
                enemyhealth--;
                Debug.Log(enemyhealth);
                WeaponScript.hashit = false;
            }
            else if(enemyhealth == 0)
            {
                Destroy(this.gameObject);
                WeaponScript.hashit = false;
            }
        }
    }
}
