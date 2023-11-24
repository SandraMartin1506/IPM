using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class Volume : MonoBehaviour
{
    public AudioMixer sfx;
    public AudioMixer songs;
    public AudioMixer voices;
    [SerializeField] private Slider All;
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
    public void SetSFXV(float volume)
    {
        sfx.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("sfx", volume);
    }
    public void SetSongsV(float volume)
    {
        songs.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("songs", volume);
    }
    public void SetVoicesV(float volume)
    {
        voices.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("voices", volume);
    }
}