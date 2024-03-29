using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]


public class Character
    {
    class Renderers
    {
        public Image renderer;

    }
    public string characterName;
    [HideInInspector] public RectTransform root;
    Renderers renderers = new Renderers();
    DialogueSystem dialogue;
   

    public Character(string cname)
    {
        
            CharacterManager cm = CharacterManager.instance;
        GameObject prefab = Resources.Load("Characters/Character[" + cname + "]" ) as GameObject;
        GameObject ob = GameObject.Instantiate(prefab, cm.characterPanel);

        root = ob.GetComponent<RectTransform>();
        characterName = cname;
        
        renderers.renderer = ob.GetComponentInChildren<Image>();
        dialogue = DialogueSystem.instance;
    }

    public void Say(string speech)
    {
        dialogue.Say(speech,characterName);
       
    }

    public DialogueSystem getDialogue()
    {
        return dialogue;
    }

    public void Deactivate()
    {
        root.gameObject.SetActive(false);
    }
  
   
}
