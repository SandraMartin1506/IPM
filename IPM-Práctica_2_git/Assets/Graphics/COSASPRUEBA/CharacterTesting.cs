using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTesting : MonoBehaviour
{
    public Character Manolo;
    public string[] speech;
    int i = 0;
    
    void Start()
    {
        Manolo = CharacterManager.instance.GetCharacter("Manolo");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if (i < speech.Length)
                Manolo.Say(speech[i]);
            else
                DialogueSystem.instance.Close();
      
            i++;
        }
        
    }
}
