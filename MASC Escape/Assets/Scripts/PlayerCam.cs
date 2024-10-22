using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float Xsens;
    public float Ysens;

    public Transform orientation;
    public float XRota;
    public float YRota;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse Input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * Xsens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * Ysens;

        YRota += mouseX;

        XRota -= mouseY;
        XRota = Mathf.Clamp(XRota, -90f, 90f);

        //Roatating Cam
        transform.rotation = Quaternion.Euler(XRota, YRota, 0);
        orientation.rotation = Quaternion.Euler(0, YRota, 0);
    }
}
