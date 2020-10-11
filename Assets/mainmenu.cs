using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public blackenScreen canvaboi;
    // Start is called before the first frame update
    void Start()
    {
        
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
