using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public bool detectPlayer = false;
    private float waitTime;
    public float startWaitTime;
    public Transform[] moveSpots;
    private int randomSpot;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        detectPlayer = false;
        randomSpot = Random.Range(0, moveSpots.Length);                                             //Zufälliges aussuchen für einen Startpunkt für das Patroullieren
    }

    // Update is called once per frame
    void Update()
    {
        if(detectPlayer)
        agent.SetDestination(target.position);                                                      //Wenn Player gesehen dann verfolge Player
        else
        {                                                                                           //Wenn nicht gehe zum vorher ausgesuchten Movespot
            agent.SetDestination(moveSpots[randomSpot].position);
            if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)        //Wenn nah genug (0.2f, nicht 1:1 auf dem Punkt, kann leicht zu fehlern führen) dann
            {
                if (waitTime <= 0)                                                                  //Randomize einen neuen Punkt wenn Wartezeit abgelaufen sonst
                {
                    randomSpot = Random.Range(0, moveSpots.Length);
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;                                                     //Reduziere die Wartezeit
                }
            }
        }
    }
}
