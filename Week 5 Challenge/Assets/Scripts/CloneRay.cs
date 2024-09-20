using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneRay : MonoBehaviour
{
    [Tooltip("Controller Input used to fire the shrink ray")]
    public OVRInput.RawButton trigger = OVRInput.RawButton.LThumbstickUp;

    [Tooltip("Object used to determine direction of fire")]
    public GameObject pointer;

    [Tooltip("Maximum distance of the raycast")]
    public float rayDistance = 100f;

    [Tooltip("Distance the duplicated object spawns from the original")]
    public float duplicateDistance = 5f;

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(trigger)){
            Ray ray = new Ray(pointer.transform.position, pointer.transform.forward);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                // Check if the ray hit an object
                GameObject hitObject = hit.collider.gameObject;

                // Duplicate the object
                DuplicateObject(hitObject, hit.point);
            }
        }
    }

    void DuplicateObject(GameObject original, Vector3 hitPoint)
    {
        // Instantiate a new object at the specified distance from the original
        Vector3 duplicatePosition = hitPoint + pointer.transform.forward * duplicateDistance;
        GameObject duplicate = Instantiate(original, duplicatePosition, Quaternion.identity);
    }
}
