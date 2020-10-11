using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public GameObject textbox;
    public string text;
    public string answer;
    public SpellCasting sCasting;
    public GameObject barrier;
    public GameObject invWall;

    // Start is called before the first frame update
    void Start()
    {
        if (sCasting == null)
        {
            GameObject.Find("SpellCasting").GetComponent<SpellCasting>();
        }
    }

    public void AcceptAnswer()
    {
        text = "Good answer";
        textbox.SetActive(false);
        textbox.SetActive(true);
        Destroy(invWall);
        textbox.GetComponent<typeText>().StartText(text);
        StartCoroutine(openBarrier());
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
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            textbox.SetActive(true);
            textbox.GetComponent<typeText>().StartText(text);
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
