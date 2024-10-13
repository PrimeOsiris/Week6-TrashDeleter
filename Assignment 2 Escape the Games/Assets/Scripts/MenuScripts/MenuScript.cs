using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject pauseMenu;

    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene(3);
    }

    public void OnResumeButton()
    {
        pauseMenu.transform.position = new Vector3(0, -10, 0);
        OVRPhysicsRaycaster PlayerClick = GetComponent<OVRPhysicsRaycaster>();
        Destroy(PlayerClick);
    }
}
