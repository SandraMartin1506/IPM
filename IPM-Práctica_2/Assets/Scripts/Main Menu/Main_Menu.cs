using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void Options()
    {
        SceneManager.LoadScene("Options", LoadSceneMode.Single);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
