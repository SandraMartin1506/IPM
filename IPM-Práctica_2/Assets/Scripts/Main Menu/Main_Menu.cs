using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    static public string Escena;
    public void Play()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    public void Options()
    {
        SceneManager.LoadScene("Options", LoadSceneMode.Single);
        Escena = "Main Menu";
    }
    public void Exit()
    {
        Application.Quit();
    }
}
