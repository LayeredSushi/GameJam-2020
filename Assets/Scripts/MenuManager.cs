using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnStartClick()
    {
        SceneManager.LoadScene("GraphicsBackground");
    }

    public void OnTutorialClick()
    {
        SceneManager.LoadScene("Tutorial3");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
