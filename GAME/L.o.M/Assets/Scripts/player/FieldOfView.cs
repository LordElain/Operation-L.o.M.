using System.Collections;
using System.Collections.Generic;
using UMotionEditor;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    public GameObject Follows;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public List<Transform> visibleTargets = new List<Transform>();

    IEnumerator FindTargetsWithDelay(float Delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(Delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        Follow FollowScript = Follows.GetComponent<Follow>();
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;                    //Richtung zum Ziel berechnen
            float dstToTarget = Vector3.Distance(transform.position, target.position);                  //Entfernung zum Ziel berechnen
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2 && dstToTarget < 3)     //Wenn im Sichtradius und Entfernung kleiner 3
            {
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))       //Raycast gibt true wenn kein Obstacle im sichtfeld ist (Raycast von mom. Pos in Richtung und Distanz des Ziels checkt nach ObstacleMask)
                {
                    FollowScript.detectPlayer = true;
                    visibleTargets.Add(target);
                }
            }
            else
                FollowScript.detectPlayer = false;
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)                               //Winkelberechnung die anpasst wenn es ein nicht globaler Winkel ist
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
    void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .2f);                                                    //Fängt Routine aller an, die aller .2 Sekunden durchläuft
    }

    // Update is called once per frame
    void Update()
    {

    }
}
