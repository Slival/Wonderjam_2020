using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class typeText : MonoBehaviour
{
    public TMP_Text TMPText;
    // Start is called before the first frame update
    void Start()
    {
        
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
            yield return new WaitForSeconds(0.06f);
            TMPText.text += c;
        }
        yield return null;
    }
}
