using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingToEscape : MonoBehaviour
{
    float loadingCounter = 5f;

    // Update is called once per frame
    void Update()
    {
        if (loadingCounter > 0)
        {
            loadingCounter -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}
