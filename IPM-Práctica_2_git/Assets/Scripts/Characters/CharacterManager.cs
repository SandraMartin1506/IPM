using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;
    public RectTransform characterPanel;
    public List<Character> characterList = new List<Character>();
    public Dictionary<string, int> characterDictionary = new Dictionary<string, int>();

    private void Awake()
    {
        instance = this;
    }
   
    public Character GetCharacter(string name, bool createCharacterIfdontExist = true, bool enableWhenAppears = true)
    {
        int index = -1;
        if(characterDictionary.TryGetValue(name, out index)) { 
        return characterList[index];
        }
        else if(createCharacterIfdontExist) 
        {
            return CreateCharacter(name, enableWhenAppears);
        }
        return null;
    }

    public Character CreateCharacter(string name, bool enableWhenAppears = true)
    {
        Character newCharacter = new Character(name);
        characterDictionary.Add(name, characterList.Count);
        characterList.Add(newCharacter);
        return newCharacter;
    }


}
