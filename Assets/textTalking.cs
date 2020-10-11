using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textTalking : MonoBehaviour
{

    public GameObject textbox;
    public string[] text;
    public SpellCasting sCasting;
    public int textIndex;
    public bool final;

    // Start is called before the first frame update
    void Start()
    {
        textIndex = 0;
        if (sCasting == null)
        {
            GameObject.Find("SpellCasting").GetComponent<SpellCasting>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (textbox.GetComponent<typeText>().finished == true && textIndex + 1 < text.Length)
        {
            textbox.GetComponent<typeText>().finished = false;
            textIndex++;
            textbox.SetActive(false);
            textbox.SetActive(true);
            textbox.GetComponent<typeText>().StartText(text[textIndex]);
            textbox.GetComponent<typeText>().finished = false;
        }
        else if (textbox.GetComponent<typeText>().finished == true && textIndex + 1 == text.Length)
        {
            final = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            textbox.SetActive(true);
            textbox.GetComponent<typeText>().StartText(text[textIndex]);
            sCasting.trigger = this.gameObject;
            sCasting.inTrigger = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            textbox.SetActive(false);
            sCasting.inTrigger = false;
        }
    }
}
