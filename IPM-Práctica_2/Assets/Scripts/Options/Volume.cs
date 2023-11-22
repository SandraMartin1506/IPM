using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using static DialogueSystem;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    public AudioMixer sfx;
    public AudioMixer songs;
    public AudioMixer voices;
    [SerializeField] private Slider SFX;
    [SerializeField] private Slider Songs;
    [SerializeField] private Slider Voices;

    public void Start()
    {
        if (PlayerPrefs.HasKey("sfx"))
        {
            SFX.value = PlayerPrefs.GetFloat("sfx");
            SetSFXV(SFX.value);
        }
        if (PlayerPrefs.HasKey("songs"))
        {
            Songs.value = PlayerPrefs.GetFloat("songs");
            SetSongsV(Songs.value);
        }
        if (PlayerPrefs.HasKey("voices"))
        {
            Voices.value = PlayerPrefs.GetFloat("voices");
            SetVoicesV(Voices.value);
        }
    }
    public void SetSFXV(float volumen)
    {
        sfx.SetFloat("volumen", volumen);
        PlayerPrefs.SetFloat("sfx", volumen);
    }
    public void SetSongsV(float volumen)
    {
        songs.SetFloat("volumen", volumen);
        PlayerPrefs.SetFloat("songs", volumen);
    }
    public void SetVoicesV(float volumen)
    {
        voices.SetFloat("volumen", volumen);
        PlayerPrefs.SetFloat("voices", volumen);
    }
}