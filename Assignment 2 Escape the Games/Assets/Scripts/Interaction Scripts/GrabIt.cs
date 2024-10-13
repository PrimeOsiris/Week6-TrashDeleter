using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabIt : MonoBehaviour
{
    [Tooltip("Tag for objects you want to pick up")]
    public string interactableTag;

    [Tooltip("Where to hold the object when picked up")]
    public Transform holdPoint;

    [Tooltip("Controller Input used to pick stuff up")]
    public OVRInput.RawButton grabber = OVRInput.RawButton.LHandTrigger;
    
    private GameObject heldObject; // Currently held object

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting");
        heldObject = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (heldObject != null && OVRInput.Get(grabber))
        {
            Debug.Log("Dropping");
            heldObject.transform.SetParent(null);
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            heldObject = null;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Colliding");
        // Check if the collided object is pickable
        if (other.gameObject.CompareTag(interactableTag) && heldObject == null)
        {
            Debug.Log("Checking & Colliding");
            // Check for pickup input (e.g., trigger button press)
            if (OVRInput.Get(grabber))
            {
                Debug.Log("Colliding & Grabbing");
                heldObject = other.gameObject;
                heldObject.transform.SetParent(holdPoint);
                heldObject.transform.localPosition = Vector3.zero;
                heldObject.transform.localRotation = holdPoint.transform.rotation;
                heldObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
}
