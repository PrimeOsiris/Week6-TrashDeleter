using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterShot : MonoBehaviour
{
    [Tooltip("Controller Input used to fire the shrink ray")]
    public OVRInput.RawButton trigger = OVRInput.RawButton.X;

    [Tooltip("Object used to determine direction of fire")]
    public GameObject pointer;

    [Tooltip("Maximum distance of the raycast")]
    public float rayDistance = 100f;

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
                Debug.DrawRay(ray.origin, ray.direction, Color.red);
                PuzzleTarget hitTarget = hitObject.GetComponent<PuzzleTarget>();
                if (hitTarget != null)
                {
                    hitTarget.SolvingHit();
                }
            }
        }
    }
}
