using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ChoiceScreen : MonoBehaviour
{
    public static ChoiceScreen instance;
    public ChoiceButton choicePrefab;
    public GameObject root;
    static List<ChoiceButton> choiceButtons = new List<ChoiceButton>();
    public VerticalLayoutGroup layoutGroup;
    public static bool isShowingChoices { get { return showingChoices != null; } }
    static Coroutine showingChoices = null;


     void Awake()
    {
        instance = this;
        Hide();
    }
    
   public static void Show(params string[] choices)
    {
        instance.root.SetActive(true);
        if (isShowingChoices)
            instance.StopCoroutine(showingChoices);
        ClearAllCurrentChoices();
        showingChoices = instance.StartCoroutine(ShowingChoices(choices));
    }
    public static void Hide()
    {
        if(isShowingChoices)
            instance.StopCoroutine(showingChoices);
        showingChoices = null;
        ClearAllCurrentChoices();
        instance.root.SetActive(false);
    }

    public static bool isWaitingForChoice { get{ return isShowingChoices && !lastChoiceMade.hasBeenMade; } }
    static void ClearAllCurrentChoices()
    {
        foreach(ChoiceButton choice in choiceButtons)
        {
            DestroyImmediate(choice.gameObject);
        }
        choiceButtons.Clear();
    }

    public static IEnumerator ShowingChoices(string[] choices)
    {
        yield return new WaitForEndOfFrame();
        lastChoiceMade.Reset();
        
        for(int i=0; i<choices.Length; i++)
        {
            CreateChoice(choices[i]);
        }

        SetLayoutSpacing();
        while (isWaitingForChoice)
            yield return new WaitForEndOfFrame();

        Hide();
    }

    public static void SetLayoutSpacing()
    {
        int i = choiceButtons.Count;
        if (i <= 3) 
            instance.layoutGroup.spacing = 20;  
        else
            instance.layoutGroup.spacing = 5;
    }
    public static void CreateChoice(string choice)
    {
        GameObject ob = Instantiate(instance.choicePrefab.gameObject,instance.choicePrefab.transform.parent);
        ob.SetActive(true);
        ChoiceButton b = ob.GetComponent<ChoiceButton>();
        b.text = choice;
        b.choiceIndex = choiceButtons.Count;
        choiceButtons.Add(b);
        
    }

    [System.Serializable]
    public class CHOICES
    {
        public bool hasBeenMade { get { return title !="" && index != -1; } }
        public int index = -1;
        public string title = "";
        public void Reset()
        {
            title = "";
            index = -1;
        }
    }
    public CHOICES choice = new CHOICES();
    public static CHOICES lastChoiceMade { get { return instance.choice; } }

    public void MakeChoice(ChoiceButton button)
    {
        choice.index = button.choiceIndex;
        choice.title = button.text;
        root.SetActive(false);

        LoadJobInfo.jobsInfo[0] = choice.title;
        HealthControl.value -= 5;

        NovelController.instance.Next();
        
    }
    
}
