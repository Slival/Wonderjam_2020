using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public GameObject textbox;
    public string[] text;
    public string answer;
    public bool hasAnswer;
    public string[] successText;
    public SpellCasting sCasting;
    public GameObject barrier;
    public GameObject invWall;
    public int textIndex;
    public int successIndex;
    public bool success;

    // Start is called before the first frame update
    void Start()
    {
        success = false;
        Debug.Log(text.Length);
        textIndex = 0;
        if (sCasting == null)
        {
            GameObject.Find("SpellCasting").GetComponent<SpellCasting>();
        }
    }

    public void AcceptAnswer()
    {
        success = true;
        textIndex = 3;
        textbox.SetActive(false);
        textbox.SetActive(true);
        textbox.GetComponent<typeText>().StartText(successText[successIndex]);
        answer = "";
        if (successIndex + 1 < successText.Length)
        {
            successIndex++;
        }
        else
        {
            successIndex = 3;
        }
        if (successIndex == 2)
        {
            openBarr();
        }
            
    }

    public void openBarr()
    {
        StartCoroutine(openBarrier());
        Destroy(invWall);
    }

    IEnumerator openBarrier()
    {
        float angle = 0;
        while (angle < 90)
        {
            barrier.transform.Rotate(new Vector3(1, 0, 0));
            angle++;
            yield return new WaitForSeconds(0.05f);
            yield return null;
        }
        yield return null;
    }

    // Update is called once per frame
    void FixedUpdate()
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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            textbox.SetActive(true);
            if (success)
            {
                textbox.GetComponent<typeText>().StartText(successText[successIndex]);
            }
            else
            {
                textbox.GetComponent<typeText>().StartText(text[textIndex]);
            }
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
