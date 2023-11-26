using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SaveLoad : MonoBehaviour
{
    List<string> data = new List<string>();
    int activeGameFileNumber = 0;
    GAMEFILE activeGameFile = null;
    string activeChapterFile = "";
    public string cachedLastSpeaker = "";

    //
    private void Start()
    {
        LoadGameFile(1);
    }
    public void LoadGameFile(int gameFileNumber)
    {
        string filePath = FileManager.savPath + "Resources/gameFiles/" + gameFileNumber.ToString() + ".txt";

        if (!System.IO.File.Exists(filePath))
        {
            FileManager.SaveJSON(filePath, new GAMEFILE());
        }

        activeGameFile = FileManager.LoadJSON<GAMEFILE>(filePath);

        data = FileManager.LoadFile(FileManager.savPath + "Resources/Story/" + activeGameFile.chapterName);
        activeChapterFile = activeGameFile.chapterName;
        cachedLastSpeaker = activeGameFile.cachedLastSpeaker;

       //DialogueSystem.instance.Open(activeGameFile.currentTextSystemSpeakerNameText, activeGameFile.currentTextSystemDisplayText);

        for (int i = 0; i < activeGameFile.charactersInScene.Count; i++)
        {
            GAMEFILE.CHARACTERDATA data = activeGameFile.charactersInScene[i];
            Character character = CharacterManager.instance.CreateCharacter(data.characterName, data.enabled);
        }

        if (activeGameFile.music != null)
            AudioManager.instance.PlaySong(activeGameFile.music);

        for (int i = 0; i < activeGameFile.jobsInfo.Count; i ++)
        {
            GAMEFILE.JOBDATA data = activeGameFile.jobsInfo[i];
            int j = i*2;
            LoadJobInfo.jobsInfo[j] = data.job;
            LoadJobInfo.jobsInfo[j+1] = data.result;
        }
        HealthControl.value = activeGameFile.health;
        /*if (handlingChapterFile != null)
            StopCoroutine(handlingChapterFile);
        handlingChapterFile = StartCoroutine(HandlingChapterFile());

        chapterProgress = activeGameFile.chapterProgress;*/
    }

    public void SaveGameFile()
    {
        string filePath = FileManager.savPath + "Resources/gameFiles/" + 1 + ".txt";

        activeGameFile.chapterName = activeChapterFile;
        //activeGameFile.chapterProgress = chapterProgress;
        activeGameFile.cachedLastSpeaker = cachedLastSpeaker;

        activeGameFile.currentTextSystemSpeakerNameText = DialogueSystem.instance.speakerNameText.text;
        activeGameFile.currentTextSystemDisplayText = DialogueSystem.instance.speechText.text;

        //activeGameFile.charactersInScene.Clear();
        /*for (int i = 0; i < CharacterManager.instance.characters.Count; i++)
        {
            Character character = CharacterManager.instance.characters[i];
            GAMEFILE.CHARACTERDATA data = new GAMEFILE.CHARACTERDATA(character);
            activeGameFile.charactersInScene.Add(data);
        }*/

        activeGameFile.jobsInfo.Clear();
        for (int i = 0; i < LoadJobInfo.jobsInfo.Length; i+=2)
        {
            string job = LoadJobInfo.jobsInfo[i];
            string result = LoadJobInfo.jobsInfo[i+1];
            activeGameFile.jobsInfo.Add(new GAMEFILE.JOBDATA(job, result));
        }
        activeGameFile.health = HealthControl.value;

        activeGameFile.music = AudioManager.activeSong != null ? AudioManager.activeSong.clip : null;

        FileManager.SaveJSON(filePath, activeGameFile);
    }
}
