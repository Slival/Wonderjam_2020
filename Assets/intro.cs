using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{

    public textTalking textTalking;
    public typeText typeText;
    public GameObject canvas;
    public GameObject canvas2;
    public bool started;
    public GameObject mechant;
    public GameObject gentil;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (textTalking.final && typeText.finished && !started)
        {
            started = true;
            StartCoroutine(introsequence());
        }
    }

    IEnumerator introsequence()
    {
        Debug.Log("Nice! we're in the intro sequence.");
        canvas.SetActive(false);
        mechant.GetComponent<Animation>().Play("scootmechant");
        yield return new WaitForSeconds(2f);
        gentil.GetComponent<Animation>().Play("scoot");
        yield return new WaitForSeconds(2f);
        canvas2.GetComponent<blackenScreen>().fout();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Intro Stelle");
        yield return null;
    }
}
