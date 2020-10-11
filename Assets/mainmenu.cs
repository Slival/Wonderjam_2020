using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public blackenScreen canvaboi;
    public GameObject credits;
    public bool creditsShown;

    // Start is called before the first frame update
    void Start()
    {
        creditsShown = false;
    }

    public void PlayGame()
    {
        StartCoroutine(startGame());
    }

    IEnumerator startGame()
    {
        canvaboi.fout();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Intro Mechant");
        yield return null;
    }

    public void showCredits()
    {
        if (!creditsShown)
        {
            credits.SetActive(true);
            creditsShown = true;
        }
        else if (creditsShown)
        {
            credits.SetActive(false);
            creditsShown = false;
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
