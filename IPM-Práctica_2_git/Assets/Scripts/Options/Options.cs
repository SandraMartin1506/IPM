using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{ 
    public void Back()
    {
        SceneManager.LoadScene(ChangeScene.lastScene);
    }

    public void LoadGame (int fileNumber)
    {
        //string filePath = FileManager.savePath
    }
}
