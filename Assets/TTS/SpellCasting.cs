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
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return) && !player.isTyping)
        {
            input.ActivateInputField();
            input.Select();
            player.isTyping = true;
        }

        if (Input.GetKeyDown(KeyCode.Return) && player.isTyping)
        {
            voice.Speak(input.text, SpeechVoiceSpeakFlags.SVSFlagsAsync | SpeechVoiceSpeakFlags.SVSFIsXML);
            input.text = "";
            player.isTyping = false;
        }
    }


}
