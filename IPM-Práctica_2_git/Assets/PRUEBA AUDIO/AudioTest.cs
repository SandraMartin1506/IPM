using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    public AudioClip clip;
    public AudioClip[] music;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.instance.PlaySFX(clip);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.instance.PlaySong(music[Random.Range(0,music.Length)]);
        }
    }
}
