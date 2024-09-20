using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [Tooltip("Adjust this to set the layer to check for collisions")]
    public LayerMask collisionLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is in the specified layer
        if (((1 << collision.gameObject.layer) & collisionLayer) != 0)
        {
            // Prevent passing through by applying a simple reaction
            Vector3 normal = collision.contacts[0].normal;
            Rigidbody rb = GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Apply a force opposite to the collision normal to push the object back
                rb.AddForce(normal/10, ForceMode.Force);
            }
        }
    }
}
