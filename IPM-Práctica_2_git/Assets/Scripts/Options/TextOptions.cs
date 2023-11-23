using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using static DialogueSystem;

public class TextOptions : MonoBehaviour
{
    static public float Size = 30;
    static public float Spacing = 1;
    static public float Kerning = 0.1f;
    [SerializeField] private Slider TextSize;
    [SerializeField] private Slider TextSpacing;
    [SerializeField] private Slider TextKerning;

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
        if (PlayerPrefs.HasKey("kerning"))
        {
            TextKerning.value = PlayerPrefs.GetFloat("kerning");
            SetKerning(TextKerning.value);
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
    public void SetKerning(float kerning)
    {
        Kerning = kerning;
        PlayerPrefs.SetFloat("kerning", kerning);
    }

    //speechText.fontSize = TextOptions.Size;
    //speechText.lineSpacing = TextOptions.Spacing;
    //speechText.characterSpacing = TextOptions.Kerning;

    //speakerNameText.characterSpacing = TextOptions.Kerning;
    //speakerNameText.fontSize = TextOptions.Size+5ish;
}
