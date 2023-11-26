using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueSystem : MonoBehaviour
{
  public static DialogueSystem instance;
  public ELEMENTS elements;
  [HideInInspector]  public bool isWatingForUserInput = false;
    string targetSpeech = "";
  
 Coroutine speaking = null;
    private void Awake()
    {
        instance = this; 
    }

    public void Say(string speech, string speaker = "")
    {
        StopSpeaking();
        speechText.text = speech;
        StartCoroutine(Speaking(speech, speaker));
    }

    public void StopSpeaking()
    {
        if (isSpeaking)
        {
            StopCoroutine(speaking);
        }
        speaking = null;
        
    }
    public bool isSpeaking { get { return speaking != null; } }
    IEnumerator Speaking(string speech, string targetSpeaker = "")
    {
        speechPanel.SetActive(true);
        targetSpeech = speech;
        speechText.text = "";
        speakerNameText.text = DetermineSpeaker(targetSpeaker);

        if(TextOptions.Size != speechText.fontSize) { speechText.fontSize = TextOptions.Size; }
        if(TextOptions.Spacing != speechText.lineSpacing) { speechText.lineSpacing = TextOptions.Spacing; }
        if(TextOptions.WordS != speechText.wordSpacing) { speechText.wordSpacing = TextOptions.WordS; }
        if(TextOptions.WordS+3 != speakerNameText.wordSpacing) { speakerNameText.wordSpacing = TextOptions.WordS + 3; }
        if(TextOptions.Size+5 != speakerNameText.fontSize) { speakerNameText.fontSize = TextOptions.Size + 5; }

        isWatingForUserInput = false;
        while(speechText.text != targetSpeech)
        {
            speechText.text += targetSpeech[speechText.text.Length];
            yield return new WaitForEndOfFrame();
        }
        isWatingForUserInput = true;
        while (isWatingForUserInput)
        {
            yield return new WaitForEndOfFrame();
            StopSpeaking();
        }
    }

    string DetermineSpeaker(string s)
    {
        string retVal = speakerNameText.text;
        if(s != speakerNameText.text)
        {
            retVal = s;
        }
        return retVal;
    }
    public void Close()
    {
        StopSpeaking() ;
        speechPanel.SetActive(false);
    }
    [System.Serializable]
    public class ELEMENTS
    {
        public GameObject speechPanel;
        public TMP_Text speakerNameText;
        public TMP_Text speechText;
    }

    public GameObject speechPanel { get { return elements.speechPanel;}}
    public TMP_Text speakerNameText { get { return elements.speakerNameText;}} 
    public TMP_Text speechText { get { return elements.speechText; } }
} 

