using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy1new;
    public GameObject enemy2new;
    public GameObject enemy3new;
    public GameObject Regal;
    public GameObject Goal;
    
    float speed = 3f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            if (!enemy1)                                                //Wenn es das gameobject nicht gibt wenn man durch den trigger läuft wird der neue auf active gesetzt
                enemy1new.SetActive(true);
            if (!enemy2)
                enemy2new.SetActive(true);
            if (!enemy3)
                enemy3new.SetActive(true);
            
            if(enemy1 && enemy2 && enemy3)
            {
                for (float i = Regal.transform.position.z; i > Goal.transform.position.z;)
                { float step = speed * Time.deltaTime;
                    Regal.transform.position = Vector3.MoveTowards(Regal.transform.position, Goal.transform.position, step);
                    i = Regal.transform.position.z;
                    Debug.Log("Bewege Regal");
                }
            }

            Destroy(this.gameObject);
        }
    }
}
