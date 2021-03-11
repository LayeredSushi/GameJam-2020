using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    TextMesh textMesh;


    void Start()
    {
        textMesh = GetComponent<TextMesh>();
        Destroy(gameObject, 1.5f);

    }


    public void SetText(string text)
    {
        GetComponent<TextMesh>().text = text;
    }
}
