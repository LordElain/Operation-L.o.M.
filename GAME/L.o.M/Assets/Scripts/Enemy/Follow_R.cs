using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow_R : MonoBehaviour
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
        randomSpot = 0;                                             //Zufälliges aussuchen für einen Startpunkt für das Patroullieren
    }

    GameObject GetWallObject(float range)                                                     //Funktion checkt was für ein Objekt sich vor der Kamera befindet und gibt dieses Gameobjekt zurück
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + moveSpots[randomSpot].transform.forward * range;
        if (Physics.Linecast(position, target, out raycastHit))
        {
            return raycastHit.collider.gameObject;
        }
        return null;
    }

    bool isWall(GameObject candidate)                                                              //Funktion gibt nur true wenn Objekt "box" ist, also auch greifbar      
    {
        return candidate.CompareTag("obstacle");
    }

    // Update is called once per frame
    void Update()
    {
        if(detectPlayer)
        agent.SetDestination(target.position);                                                      //Wenn Player gesehen dann verfolge Player
        else
        {                                                                                           //Wenn nicht gehe zum vorher ausgesuchten Movespot
            agent.SetDestination(moveSpots[randomSpot].position);
            if (isWall(GetWallObject(Vector3.Distance(transform.position, moveSpots[randomSpot].position))))
            {
                Debug.Log("WAND DAZWISCHEN");
                randomSpot = Random.Range(0, moveSpots.Length);
            }
            else
            {
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
}
