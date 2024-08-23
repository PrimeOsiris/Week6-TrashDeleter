using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    void HitMessage()
    {
        var ObjRenderer = gameObject.GetComponent<Renderer>();
        ObjRenderer.material.color = Color.red;
        UnityEngine.Debug.Log("Collided");
    }
}
