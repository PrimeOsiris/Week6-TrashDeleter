using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickInteraction : MonoBehaviour
{
    public float rayLength = 3.0f;
    public LayerMask interactableLayer = 5;
    public GameObject pointer;
    public OVRInput.RawButton clicker = OVRInput.RawButton.RIndexTrigger;
    

    // Start is called before the first frame update
    void Start()
    {
        if(this.GetComponent<ControllerMove>() == true)
        {
            pointer = this.GetComponent<ControllerMove>().pointer;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(pointer.transform.position, pointer.transform.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction*rayLength, Color.yellow);

        if (Physics.Raycast(ray, out hit, rayLength, interactableLayer))
        {
            if (OVRInput.Get(clicker))
            {
                MenuScript interactable = hit.collider.GetComponent<MenuScript>();
                if (interactable != null && interactable.gameObject.CompareTag("PlayButton"))
                {
                    interactable.OnPlayButton();
                }
                if (interactable != null && interactable.gameObject.CompareTag("QuitButton"))
                {
                    interactable.OnQuitButton();
                }
                if (interactable != null && interactable.gameObject.CompareTag("MenuButton"))
                {
                    interactable.OnMenuButton();
                }
                if (interactable != null && interactable.gameObject.CompareTag("ResumeButton"))
                {
                    interactable.OnMenuButton();
                }
            }
        }
    }
}
