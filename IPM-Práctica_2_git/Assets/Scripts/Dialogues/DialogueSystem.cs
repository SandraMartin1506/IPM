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
  
 Coroutine speaking = null;
    private void Awake()
    {
        instance = this; 
    }

    public void Say(string speech, string speaker = "")
    {
        StopSpeaking();
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
    IEnumerator Speaking(string targetSpeech, string targetSpeaker = "")
    {
        speechPanel.SetActive(true);
        speechText.text = "";
        speakerNameText.text = DetermineSpeaker(targetSpeaker);
        if(TextOptions.Size != speechText.fontSize) { speechText.fontSize = TextOptions.Size; }

        speechText.lineSpacing = TextOptions.Spacing;
        speechText.wordSpacing = TextOptions.WordS;
        speakerNameText.wordSpacing = TextOptions.WordS+3;
        speakerNameText.fontSize = TextOptions.Size+5;

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

        //speechText.fontSize = TextOptions.Size;
        //speechText.lineSpacing = TextOptions.Spacing;
        //speechText.characterSpacing = TextOptions.Kerning;
        //speakerNameText.characterSpacing = TextOptions.Kerning;
        //speakerNameText.fontSize = TextOptions.Size+5ish;
    }

    public GameObject speechPanel { get { return elements.speechPanel;}}
    public TMP_Text speakerNameText { get { return elements.speakerNameText;}} 
    public TMP_Text speechText { get { return elements.speechText; } }
} 

