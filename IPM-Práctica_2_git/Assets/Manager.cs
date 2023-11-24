using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Drawing;
using Unity.Collections.LowLevel.Unsafe;

public class Manager : MonoBehaviour
{
    public AudioMixer sfx;
    public AudioMixer songs;
    public AudioMixer voices;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("size"))
        {
            TextOptions.Size = PlayerPrefs.GetFloat("size");
        }
        if (PlayerPrefs.HasKey("spacing"))
        {
            TextOptions.Spacing = PlayerPrefs.GetFloat("spacing");
        }
        if (PlayerPrefs.HasKey("wordS"))
        {
            TextOptions.WordS = PlayerPrefs.GetFloat("wordS");
        }
    }
    public void Start()
    {
        if (PlayerPrefs.HasKey("sfx"))
        {
            sfx.SetFloat("volume", PlayerPrefs.GetFloat("sfx"));
        }
        if (PlayerPrefs.HasKey("songs"))
        {
            songs.SetFloat("volume", PlayerPrefs.GetFloat("songs"));
        }
    }
}
