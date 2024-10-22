using System.Collections;
using System.Collections.Generic;
using Meta.WitAi;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseScript : MonoBehaviour
{
    [Tooltip("The the pause menu.")]
    public GameObject PauseMenu;

    [Tooltip("The Game object the player controls.")]
    public GameObject Player;

    private GameObject ExistingMenu;

    [Tooltip("The pause button.")]
    public OVRInput.RawButton pause = OVRInput.RawButton.A;

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(pause) && ExistingMenu == null)
        {
            ExistingMenu = PauseMenu;
            if (Player.transform.eulerAngles.y <= 45)
            {
                ExistingMenu.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1, Player.transform.position.z + 1);
            }
            if (Player.transform.eulerAngles.y >= 45 && Player.transform.eulerAngles.y <= 135)
            {
                ExistingMenu.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1, Player.transform.position.z  + 1);
                //ExistingMenu.transform.Rotate(0, Player.transform.eulerAngles.y - 180 ,0);
            }
            if (Player.transform.eulerAngles.y >= 135 && Player.transform.eulerAngles.y <= 225)
            {
                ExistingMenu.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1, Player.transform.position.z - 1);
            }
            if (Player.transform.eulerAngles.y >= 225 && Player.transform.eulerAngles.y <= 315)
            {
                ExistingMenu.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1, Player.transform.position.z - 1);
                //ExistingMenu.transform.rotation = new Quaternion(0, Player.transform.eulerAngles.y + 180, 0, );
            }
            Player.AddComponent<OVRPhysicsRaycaster>();
            OVRPhysicsRaycaster PlayerClick = GetComponent<OVRPhysicsRaycaster>();
            PlayerClick.eventMask = 5;
        }
        else if (OVRInput.Get(pause) && ExistingMenu != null)
        {
            ExistingMenu.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - 10, Player.transform.position.z);
            ExistingMenu = null;
            OVRPhysicsRaycaster PlayerClick = GetComponent<OVRPhysicsRaycaster>();
            Destroy(PlayerClick);
        }
    }
}
