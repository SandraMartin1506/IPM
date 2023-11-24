using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using static DialogueSystem;

public class TextOptions : MonoBehaviour
{
    static public float Size;
    static public float Spacing;
    static public float WordS;
    [SerializeField] private Slider TextSize;
    [SerializeField] private Slider TextSpacing;
    [SerializeField] private Slider TextWordS;

    public void Start()
    {
        if (PlayerPrefs.HasKey("size"))
        {
            TextSize.value = PlayerPrefs.GetFloat("size");
            SetSize(TextSize.value);
        }
        if (PlayerPrefs.HasKey("spacing"))
        {
            TextSpacing.value = PlayerPrefs.GetFloat("spacing");
            SetSpacing(TextSpacing.value);
        }
        if (PlayerPrefs.HasKey("wordS"))
        {
            TextWordS.value = PlayerPrefs.GetFloat("wordS");
            SetWordS(TextWordS.value);
        }
    }
    public void SetSize(float size)
    {
        Size = size;
        PlayerPrefs.SetFloat("size", size);
    }
    public void SetSpacing(float spacing)
    {
        Spacing = spacing;
        PlayerPrefs.SetFloat("spacing", spacing);
    }
    public void SetWordS(float wordS)
    {
        WordS = wordS;
        PlayerPrefs.SetFloat("wordS", wordS);
    }

    //speechText.fontSize = TextOptions.Size;
    //speechText.lineSpacing = TextOptions.Spacing;
    //speechText.characterSpacing = TextOptions.Kerning;

    //speakerNameText.characterSpacing = TextOptions.Kerning;
    //speakerNameText.fontSize = TextOptions.Size+5ish;
}
