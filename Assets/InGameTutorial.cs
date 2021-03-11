using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InGameTutorial : MonoBehaviour
{
    bool listen;
    int frame;
    TextMesh text;

    private static InGameTutorial instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = gameObject.GetComponent<InGameTutorial>();
        else
            Destroy(gameObject);
    }

	void Start()
    {
        text = GetComponent<TextMesh>();
        listen = false;
        frame = 0;
        StartCoroutine(ReadyToListen());
    }

    IEnumerator ReadyToListen()
	{
        yield return new WaitForSeconds(1f);
        listen = true;
	}
    // Update is called once per frame
    void Update()
    {
        if (listen && frame == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                frame++;
                text.text = "To switch the spell \n use 1 and 2 kyeboard keys";
            }
        }
        if(frame==1){
            if(Input.GetKeyDown("1")|| Input.GetKeyDown("2"))
		    {
                frame++;
                text.text = "To start over press R";
            }

        }

		if (frame == 2)
		{
            frame++;
            StartCoroutine(EndingCourutine());
		}
            

    }

    IEnumerator EndingCourutine()
	{
        yield return new WaitForSeconds(5f);
        text.text = "";
	}
}
