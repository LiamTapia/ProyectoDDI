using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;
using IBM.Watsson.Examples;
public class VoiceCommandPausa : MonoBehaviour
{
    public string voiceCommand = "start";
    public GameObject menu;

    void Awake() 
    {
        VoiceCommandProcessor commandProcessor = GameObject.FindObjectOfType<VoiceCommandProcessor>();
        //commandProcessor.onVoiceCommandRecognized += OnVoiceCommandRecognized;
    }

    public void OnVoiceCommandRecognized(string command)
    {
        if(command.ToLower().Contains(voiceCommand.ToLower()))
        {
            menu.SetActive(true);
        }
    }
}
