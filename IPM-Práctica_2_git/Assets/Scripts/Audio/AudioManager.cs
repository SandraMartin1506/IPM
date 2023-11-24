using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public static SONG activeSong = null;
    public static List<SONG> songs = new List<SONG>();

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public void PlaySFX(AudioClip effect)
    {
        AudioSource source = CreateNewSource(string.Format("SFX[{0}]", effect.name));
        AudioMixer audioMixer = Resources.Load<AudioMixer>("SFX");
        AudioMixerGroup[] audioMixGroup = audioMixer.FindMatchingGroups("Master");
        source.outputAudioMixerGroup = audioMixGroup[0];
        source.clip = effect;
        source.Play();
        Destroy(source.gameObject, effect.length);
    }

    public void PlaySong(AudioClip song, bool playOnStart = true, bool loop = true)
    {
        if(song != null)
        {
            for(int i = 0; i < songs.Count; i++)
            {
                SONG s = songs[i];
                if (s != null && s.isPlaying())
                {
                    s.Stop();
                }
                if(s.clip == song)
                {
                    activeSong = s;
                    s.Play();
                    break;
                }
            }
            if (activeSong == null || activeSong.clip != song)
                activeSong = new SONG(song, playOnStart, loop);
        }
        else
            activeSong = null;
    }

    public static AudioSource CreateNewSource(string _name)
    {
        AudioSource newSource = new GameObject(_name).AddComponent<AudioSource>();
        newSource.transform.SetParent(instance.transform);
        return newSource;
    }

    [System.Serializable]
    public class SONG
    {
        public AudioSource source;
        public AudioClip clip { get { return source.clip; } set { source.clip = value; } }

        public SONG(AudioClip clip, bool playOnStart, bool loop)
        {
            source = AudioManager.CreateNewSource(string.Format("SONG [{0}]", clip.name));
            AudioMixer audioMixer = Resources.Load<AudioMixer>("Songs");
            AudioMixerGroup[] audioMixGroup = audioMixer.FindMatchingGroups("Master");
            source.outputAudioMixerGroup = audioMixGroup[0]; 
            source.clip = clip;
            source.loop = loop;

            AudioManager.songs.Add(this);

            if(playOnStart)
                source.Play();
        }

        public float volume { get { return source.volume; } set { source.volume = value; } }

        public void Play() { source.Play(); }

        public void Stop() { source.Stop(); }

        public void Pause() { source.Pause(); }

        public void UnPause() { source.UnPause(); }

        public bool isPlaying() { return source.isPlaying; }

        public void DestroySong()
        {
            AudioManager.songs.Remove(this);
            DestroyImmediate(source.gameObject);
        }
    }
}
