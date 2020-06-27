using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject Player;
    public GameObject ending;
    public Text resapwned;

    bool entered = false;
    
    float speed = 1f;                                                   // Wie Schnell wird das Regal bewegt

    private void FixedUpdate()
    {
        //Debug.Log(Vector3.Distance(Player.transform.position, this.transform.position));
        if (Vector3.Distance(Player.transform.position,this.transform.position) < 6)
        {
            if (!enemy1)                                                //Wenn es das gameobject nicht gibt wenn man durch den trigger läuft wird der neue auf active gesetzt
                enemy1new.SetActive(true);
            if (!enemy2)
                enemy2new.SetActive(true);
            if (!enemy3)
                enemy3new.SetActive(true);
            entered = true;
            resapwned.text = "Enemies have respawned, and they are STRONGER!";
        }
        if (entered)
        {
            if (!enemy1 || !enemy2 || !enemy3)
            {
                float step = speed * Time.deltaTime;
                Regal.transform.position = Vector3.MoveTowards(Regal.transform.position, Goal.transform.position, step);            //Bewegt Regal von seiner Position zur Goal position
                //Debug.Log("Bewege Regal");
            }
            if (Regal.transform.position == Goal.transform.position)
            {
                ending.SetActive(true);
                resapwned.text = " ";
                Destroy(this.gameObject);
            }
            ending.SetActive(true);
            resapwned.text = " ";
        }
    }
}
