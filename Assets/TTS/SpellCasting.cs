using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using SpeechLib;
using System.Xml;
using System.IO;

public class SpellCasting : MonoBehaviour
{
    TMP_InputField input;
    private SpVoice voice;
    PlayerVariables player;

    public GameObject fireballPrefab;
    public GameObject iceProjectilePrefab;


    string loadXMLStandalone(string fileName)
    {

        string path = Path.Combine("Resources", fileName);
        path = Path.Combine(Application.dataPath, path);
        Debug.Log("Path:  " + path);
        StreamReader streamReader = new StreamReader(path);
        string streamString = streamReader.ReadToEnd();
        Debug.Log("STREAM XML STRING: " + streamString);
        return streamString;
    }

    private void Start()
    {
        voice = new SpVoice();
        input = GetComponent<TMP_InputField>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerVariables>();
        input.enabled = false;
    }

    IEnumerator OpenInput()
    {
        yield return new WaitForSeconds(0.1f);
        player.isTyping = true;
        yield return null;
    }

    IEnumerator CloseInput()
    {
        yield return new WaitForSeconds(0.1f);
        player.isTyping = false;
        yield return null;
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return) && !player.isTyping)
        {
            input.enabled = true;
            input.Select();
            input.ActivateInputField();
            StartCoroutine(OpenInput());
        }

        if (Input.GetKeyDown(KeyCode.Return) && player.isTyping)
        {

            voice.Speak(input.text, SpeechVoiceSpeakFlags.SVSFlagsAsync | SpeechVoiceSpeakFlags.SVSFIsXML);
            Cast(input.text);
            input.text = "";
            input.enabled = false;
            StartCoroutine(CloseInput());
        }
    }

    void Cast(string spellName)
    {
        if (spellName.ToLower() == "fireball" || spellName.ToLower() == "boule de feu")
        {
            GameObject fireball = Instantiate(fireballPrefab);
            float direction = 1;
            if (player.GetComponent<PlayerMovement>().goingLeft)
            {
                fireball.transform.Rotate(new Vector3(135, 0, 0));
                direction = -1;
            } else
            {
                fireball.transform.Rotate(new Vector3(35, 0, 0));
                direction = 1;
            }

            fireball.transform.position = new Vector3(player.transform.position.x + direction/10, player.transform.position.y, player.transform.position.z);
            fireball.GetComponent<Rigidbody>().velocity = new Vector3(direction, 1, 0);
        }
        if (spellName.ToLower() == "arcane jump" || spellName.ToLower() == "super saut")
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.up*1000);
        }
        if (spellName.ToLower() == "stop time" || spellName.ToLower() == "temps mort")
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * 1000);
        }
        if (spellName.ToLower() == "ice barrier" || spellName.ToLower() == "barriere de glace" || spellName.ToLower() == "barrière de glace")
        {
            GameObject fireball = Instantiate(iceProjectilePrefab);
            float direction = 1;
            if (player.GetComponent<PlayerMovement>().goingLeft)
            {
                fireball.transform.Rotate(new Vector3(135, 0, 0));
                direction = -1;
            }
            else
            {
                fireball.transform.Rotate(new Vector3(35, 0, 0));
                direction = 1;
            }

            fireball.transform.position = new Vector3(player.transform.position.x + direction / 10, player.transform.position.y, player.transform.position.z);
            fireball.GetComponent<Rigidbody>().velocity = new Vector3(direction, 1, 0);
        }
        if (spellName.ToLower() == "lightning strike" || spellName.ToLower() == "eclair" || spellName.ToLower() == "éclair")
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * 1000);
        }
        if (spellName.ToLower() == "giant" || spellName.ToLower() == "geant" || spellName.ToLower() == "géant")
        {
            player.transform.localScale *= 1.2f;
        }
        if (spellName.ToLower() == "macro")
        {
            player.transform.localScale += new Vector3(1.2f, 1.2f, 1.2f);
        }
    }

}
