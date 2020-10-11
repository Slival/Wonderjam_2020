using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blackenScreen : MonoBehaviour
{
    public GameObject player;
    public float alpha;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    IEnumerator FadeIn()
    {
        alpha = 1;
        while (alpha > 0)
        {
            gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            alpha -= 0.01f;
            yield return new WaitForSeconds(0.005f);
        }
        yield return null;
    }

    public void fout()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        alpha = 0;
        while (alpha < 1)
        {
            gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            alpha += 0.01f;
            yield return new WaitForSeconds(0.005f);
        }
        yield return null;
    }

}
