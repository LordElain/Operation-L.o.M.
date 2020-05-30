using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbing : MonoBehaviour
{

    GameObject grabbedObject;

    GameObject GetMouseHoverObject(float range)
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

    void TryGrabObject(GameObject grabObject)
    {
        if (grabObject == null ||!CanGrab(grabObject))
            return;

        grabbedObject = grabObject;
        Debug.Log(grabObject);
    }

    bool CanGrab(GameObject candidate)
    {
        return candidate.CompareTag("box");
    }

    void DropObject()
    {
        if (grabbedObject == null)
            return;

        if (grabbedObject.GetComponent<Rigidbody>() != null)
            grabbedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        grabbedObject = null;
    }
    
    void Update()
    {
        if (Input.GetKey("e"))
        {
            if (grabbedObject == null)
                TryGrabObject(GetMouseHoverObject(5));
            else
                DropObject();
        }

        if(grabbedObject != null)
        {
            Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * 3;
            grabbedObject.transform.position = newPosition;
        }
    }
}
