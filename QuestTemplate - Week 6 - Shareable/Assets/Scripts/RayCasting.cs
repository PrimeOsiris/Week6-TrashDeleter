using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    public OVRInput.RawButton button = OVRInput.RawButton.RIndexTrigger;
    private Renderer objRenderer;

    public string TargetTag;
    // Start is called before the first frame update
    void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(button)){
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitData;
            UnityEngine.Debug.DrawRay(ray.origin, ray.direction * 10);

            if(Physics.Raycast(transform.position, transform.TransformDirection(UnityEngine.Vector3.forward), out hitData, Mathf.Infinity))
            {
                if (hitData.transform.gameObject.tag == TargetTag){
                    Destroy(hitData.transform.gameObject);
                }
                else{
                    Debug.Log("Miss");
                }
            }
        }
        
    }
}
