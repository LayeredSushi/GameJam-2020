using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialUI : MonoBehaviour
{
    private Canvas[] canvases;
    private int canvasIndex;
    // Start is called before the first frame update
    void Start()
    {
        canvases = GetComponentsInChildren<Canvas>();
        canvasIndex = 1;

        foreach(Canvas canvas in canvases)
        {
            canvas.gameObject.SetActive(false);
        }
        canvases[canvasIndex].gameObject.SetActive(true);
        canvases[0].gameObject.SetActive(true);
    }

    public void OnNextClick()
    {
        canvases[canvasIndex].gameObject.SetActive(false);
        canvasIndex++;
        if (canvasIndex == canvases.Length)
        {
            SceneManager.LoadScene("Menu");
        }
        if(canvasIndex < canvases.Length)
            canvases[canvasIndex].gameObject.SetActive(true);
    }

    public void OnMenuClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
