using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    DialogueSystem dialogue;
    public string[] s = new string[]
    {
        "Babygirl do you come here often?",
        "Manolo qué haces hablando inglés si eres cacereño",
        "Jodeer Carmen..."
    };
    int index = 0;
    void Start()
    {
        dialogue = DialogueSystem.instance;
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyUp(KeyCode.Space)) {
        if(!dialogue.isSpeaking || dialogue.isWatingForUserInput)
            {
                if (index >= s.Length) {
                    return;

                }

                Say(s[index]);
                index++;
            }
        }   
    }

    void Say(string s)
    {
        string[] parts = s.Split(':');
        string speech = parts[0];
        string speaker = (parts.Length >= 2) ? parts[1] : "";

        dialogue.Say(speech, speaker);
    }
}
