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
    public int Spot;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        detectPlayer = false;
        Spot = 0;
        waitTime = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (detectPlayer)
            agent.SetDestination(target.position);                                                      //Wenn Player gesehen dann verfolge Player
        else
        {                                                                                               //Wenn nicht gehe zum vorher ausgesuchten Movespot
            agent.SetDestination(moveSpots[Spot].position);
            Debug.Log(Vector3.Distance(transform.position, moveSpots[Spot].position));
            if (Vector3.Distance(transform.position, moveSpots[Spot].position) < 0.5f)                  //Wenn nah genug (0.2f, nicht 1:1 auf dem Punkt, kann leicht zu fehlern führen) dann
            {
                if (waitTime <= 0)                                                                  
                {
                    if (Spot >= moveSpots.Length - 1)
                    {
                        Spot = 0;
                        waitTime = startWaitTime;
                    }
                    else
                    {
                        waitTime = startWaitTime;
                        Spot++;                                                                        //Gehe alle movespots durch
                        Debug.Log(Spot);
                    }
                }
                else
                {
                    waitTime -= Time.deltaTime;                                                         //Reduziere die Wartezeit
                    Debug.Log(Spot);
                }
            }

        }
    }
}
