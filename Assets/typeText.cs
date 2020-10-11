using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class typeText : MonoBehaviour
{
    public TMP_Text TMPText;
    public bool finished;
    // Start is called before the first frame update
    void Start()
    {
        finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartText(string text)
    {
        StartCoroutine(c_StartText(text));
    }

    IEnumerator c_StartText(string text)
    {
        TMPText.text = "";
        foreach (char c in text)
        {
            yield return new WaitForSecondsRealtime(0.04f);
            TMPText.text += c;
        }
        yield return new WaitForSecondsRealtime(2);
        finished = true;
        yield return null;

    }
}
