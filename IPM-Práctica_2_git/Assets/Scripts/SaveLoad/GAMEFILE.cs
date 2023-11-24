using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GAMEFILE
{
    public string chapterName;
    public int chapterProgress = 0;

    public string cachedLastSpeaker = "";

    public string currentTextSystemSpeakerNameText = "";
    public string currentTextSystemDisplayText = "";

    public float health;

    public List<CHARACTERDATA> charactersInScene = new List<CHARACTERDATA>();
    public List<JOBDATA> jobsInfo = new List<JOBDATA>();

    public Texture background = null;

    public AudioClip music = null;

    public GAMEFILE()
    {
        this.chapterName = "story_chap0a";
        this.chapterProgress = 0;
        this.cachedLastSpeaker = "";

        this.background = null;

        this.music = null;

        charactersInScene = new List<CHARACTERDATA>();

        /*this.jobsInfo = new string[6];
        for(int i = 0; i < this.jobsInfo.Length; i++)
        {
            this.jobsInfo[i] = "??";
        }*/
        this.health = 80;
    }

    [System.Serializable]
    public class CHARACTERDATA
    {
        public string characterName = "";
        public bool enabled = true;
        public string facialExpression = "";
        public string bodyExpression = "";
        public bool facingLeft = true;
        public Vector2 position = Vector2.zero;

        public CHARACTERDATA(Character character)
        {
            this.characterName = character.characterName;
            //this.enabled = character.isVisibleInScene;
            //this.position = character._targetPosition;
        }
    }
    [System.Serializable]
    public class JOBDATA
    {
        public string job = "??";
        public string result = "??";

        public JOBDATA(string job, string result)
        {
            this.job = job;
            this.result = result;
        }
    }
}
