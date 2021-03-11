using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenuUI : MonoBehaviour
{
    public GameState gs;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Your score: " + gs.score.ToString();
    }

    public void OnRestartPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GraphicsBackground");
    }

    public void OnExitPressed()
    {
        Application.Quit();
    }
}
