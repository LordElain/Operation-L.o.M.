using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGrab : MonoBehaviour
{
    private Vector3 Boden;
    GameObject grabbedObject;

    void Start()
    {
        Boden = Vector3.zero;
    }
    GameObject GetMouseHoverObject(float range)                                                     //Funktion checkt was für ein Objekt sich vor der Kamera befindet und gibt dieses Gameobjekt zurück
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;
        if(Physics.Linecast(position,target,out raycastHit))
        {
            return raycastHit.collider.gameObject;
        }
        return null;
    }

    void TryGrabObject(GameObject grabObject)                                                       //Funktion probiert ob ein greifbares Objekt vorhanden ist
    {
        if (grabObject == null ||!CanGrab(grabObject))
            return;

        grabbedObject = grabObject;
    }

    bool CanGrab(GameObject candidate)                                                              //Funktion gibt nur true wenn Objekt "box" ist, also auch greifbar      
    {
        return candidate.CompareTag("box");
    }

    void DropObject()                                                                               // Wenn man schon ein Objekt hält wird wird es gedropped sonst einfach return
    {
        if (grabbedObject == null)
            return;

        if (grabbedObject.GetComponent<Rigidbody>() != null)
            grabbedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;                        //Wenn das gegriffene Objekt einen Rigidbody hat wird dessen velocitiy auf 0 gesetzt damit es nicht wild wegfliegt wenn amn es loslässt
        grabbedObject = null;
    }
    
    void Update()
    {
        if (Input.GetKey("e"))                                                                      //Wenn "e" wird gegriffen, wenn schon ein grabbedObject da ist wird fallengelassen
        {
            if (grabbedObject == null)
                TryGrabObject(GetMouseHoverObject(5));
            else
                DropObject();
        }

        if(grabbedObject != null)
        {
            Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * 2;                //Wie weit das gegrabbete Objekt vor dem Spieler ist                                                       
            grabbedObject.transform.position = newPosition;                                                         //Behält gegriffenes Objekt direkt vor dem Spieler
        }
    }
}
