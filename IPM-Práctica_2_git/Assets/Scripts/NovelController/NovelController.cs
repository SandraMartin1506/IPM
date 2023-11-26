using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovelController : MonoBehaviour
{
   List<string> data = new List<string>();
    List<string> choices = new List<string>();
    int progress = 0;
    string cachedLastSpeaker;
    bool next = false;
    public static NovelController instance;

    private void Awake()
    {
        instance = this; 
    }
    void Start()
    {
        loadChapterFile("chapter0");
        handeLine(data[progress]);
        progress++;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Next();
        }
        if (next)
        {
            GameFlow();
        }
        next = false;
    }

    void GameFlow()
    {
        handeLine(data[progress]);
        
    }
   public  void Next()
    {
        progress++;
        next = true;

    }

    public void loadChapterFile(string name)
    {
        data = FileManager.LoadFile(FileManager.savPath + "Resources/Story/" + name);
    }

    void handeLine(string line)
    {
        string[] dialogue = line.Split('"');

        if (dialogue.Length > 0)
        {
            StartCoroutine(HandleDialogueAndChoices(dialogue[0], dialogue[1]));
        }
    }

    IEnumerator HandleDialogueAndChoices(string dialogueDetails, string dialogue)
    {
        handleDialogue(dialogueDetails, dialogue);

        
        yield return new WaitForSeconds(0.5f); 
        if (HasMoreLines() && NextLineIsChoice())
        {
            progress++;  
            handleChoices(data[progress]);
        }
        deactivateCharacter();
    }
    bool HasMoreLines()
    {
        return progress + 1 < data.Count;
    }

    bool NextLineIsChoice()
    {
        return data[progress + 1].StartsWith("choice");
    }
    void handleDialogue(string dialogueDetails, string dialogue)
    {
        string speaker = cachedLastSpeaker;

       if(dialogueDetails.Length > 0 )
        {
            //Quita el espacio de después del nombre de personaje en mi diálogo
            if (dialogueDetails[dialogueDetails.Length - 1] == ' ')
            {
                dialogueDetails = dialogueDetails.Remove(dialogueDetails.Length - 1);

                speaker = dialogueDetails;
                cachedLastSpeaker= speaker;
            }
        }
                Character character = CharacterManager.instance.GetCharacter(speaker);
                character.Say(dialogue);
         
    }

    void deactivateCharacter() {
        if (data[progress+1].StartsWith("deactivate"))
        {
            Character character = CharacterManager.instance.GetCharacter(cachedLastSpeaker);
            character.Deactivate();
            progress++;
        }
    }

    void handleChoices(string line)
    {
        bool gatheringChoices = true;
        while (gatheringChoices)
        {
            progress++;
            line = data[progress];
            if (line == "{")
                continue;
            if (line != "}")
            {
                choices.Add(line);
                
            }
            else
            {
                gatheringChoices = false;

            }
        }
        if (choices.Count > 0)
        {
            
            ChoiceScreen.Show(choices.ToArray());
        }
         choices.Clear();
    }

}
